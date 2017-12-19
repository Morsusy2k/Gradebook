using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Gradebook.DataAccessLayer.Models;
using Gradebook.RepositoryLayer.Interfaces;
using Gradebook.Utilities.Common.Extensions;
using Gradebook.Utilities.Common;

namespace Gradebook.DataAccessLayer.SQLAccess.Providers
{
    public class FieldProvider : IFieldInterface
    {
        private readonly string _connectionString = AppSettings.ConnectionString;

        #region [ReadMethods]

        public List<FieldOfStudy> GetAllFields()
        {
            List<FieldOfStudy> result = new List<FieldOfStudy>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("FieldOfStudyGetAll", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result.Add(DBAccessExtensions.MapTableEntityTo<FieldOfStudy>(reader));
                            }
                        }
                    }
                }
            }

            return result;
        }
        public FieldOfStudy GetFieldById(int id)
        {
            FieldOfStudy result = null;

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("FieldOfStudyGetById", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result = DBAccessExtensions.MapTableEntityTo<FieldOfStudy>(reader);
                            }
                        }
                    }
                }
            }

            return result;
        }

        #endregion

        #region [WriteMethods]

        public FieldOfStudy InsertField(FieldOfStudy field, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("FieldOfStudyInsert", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    return InsertFieldSqlCommand(sqlCommand, field);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("FieldOfStudyInsert", sqlConnection))
                    {
                        return InsertFieldSqlCommand(sqlCommand, field);
                    }
                }
            }
        }

        public void InsertFieldSubject(FieldOfStudy field, Subject subject, int creatorId, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("FieldOfStudyInsertSubject", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    InsertFieldSubjectSqlCommand(sqlCommand, field, subject, creatorId);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("FieldOfStudyInsertSubject", sqlConnection))
                    {
                        InsertFieldSubjectSqlCommand(sqlCommand, field, subject, creatorId);
                    }
                }
            }
        }

        public FieldOfStudy UpdateField(FieldOfStudy field, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("FieldOfStudyUpdate", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    return UpdateFieldSqlCommand(sqlCommand, field);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("FieldOfStudyUpdate", sqlConnection))
                    {
                        return UpdateFieldSqlCommand(sqlCommand, field);
                    }
                }
            }
        }
        public void DeleteField(FieldOfStudy field, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("FieldOfStudyDelete", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    DeleteFieldSqlCommand(sqlCommand, field);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("FieldOfStudyDelete", sqlConnection))
                    {
                        DeleteFieldSqlCommand(sqlCommand, field);
                    }
                }
            }
        }

        public void DeleteFieldSubjects(FieldOfStudy field, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("FieldOfStudyDeleteSubjects", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    DeleteFieldSubjectsSqlCommand(sqlCommand, field);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("FieldOfStudyDeleteSubjects", sqlConnection))
                    {
                        DeleteFieldSubjectsSqlCommand(sqlCommand, field);
                    }
                }
            }
        }

        public ITransaction CreateNewTransaction()
        {
            return new AdoTransaction(_connectionString);
        }
        #endregion

        #region [SqlCommandMethods]

        public FieldOfStudy InsertFieldSqlCommand(SqlCommand sqlCommand, FieldOfStudy field)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Name", field.Name);
            sqlCommand.Parameters.AddWithValue("@CreatedBy", field.CreatedBy);
            sqlCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

            SqlParameter outputIdParam = new SqlParameter("@Id", SqlDbType.Int);
            outputIdParam.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(outputIdParam);

            SqlParameter outputVersionParam = new SqlParameter("@Version", SqlDbType.Timestamp);
            outputVersionParam.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(outputVersionParam);

            sqlCommand.ExecuteNonQuery();

            field.Id = Convert.ToInt32(outputIdParam.Value);
            field.Version = (byte[])(outputVersionParam.Value);

            return field;
        }

        public void InsertFieldSubjectSqlCommand(SqlCommand sqlCommand, FieldOfStudy field, Subject subject, int creatorId)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@FieldId", field.Id);
            sqlCommand.Parameters.AddWithValue("@SubjectId", subject.Id);
            sqlCommand.Parameters.AddWithValue("@CreatedBy", creatorId);
            sqlCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

            sqlCommand.ExecuteNonQuery();

        }

        public FieldOfStudy UpdateFieldSqlCommand(SqlCommand sqlCommand, FieldOfStudy field)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", field.Id);
            sqlCommand.Parameters.AddWithValue("@Name", field.Name);
            sqlCommand.Parameters.AddWithValue("@ModifiedBy", field.ModifiedBy);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

            SqlParameter outputVersionParam = new SqlParameter("@Version", SqlDbType.Timestamp);
            outputVersionParam.Direction = ParameterDirection.InputOutput;
            outputVersionParam.Value = field.Version;
            sqlCommand.Parameters.Add(outputVersionParam);

            int result = sqlCommand.ExecuteNonQuery();
            field.Version = (byte[])(outputVersionParam.Value);

            if (result == 0)
            {
                throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before updating.");
            }

            return field;
        }

        public void DeleteFieldSqlCommand(SqlCommand sqlCommand, FieldOfStudy field)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", field.Id);
            sqlCommand.Parameters.AddWithValue("@Version", field.Version);

            int result = sqlCommand.ExecuteNonQuery();

            if (result == 0)
            {
                throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before deleting.");
            }
        }


        public void DeleteFieldSubjectsSqlCommand(SqlCommand sqlCommand, FieldOfStudy field)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@FieldId", field.Id);

            int result = sqlCommand.ExecuteNonQuery();

            /*if (result == 0)
            {
                throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before deleting.");
            }*/
        }
        #endregion

    }
}
