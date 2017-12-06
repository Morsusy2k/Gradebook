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
    public class SubjectProvider : ISubjectInterface
    {
        private readonly string _connectionString = AppSettings.ConnectionString;

        #region [ReadMethods]

        public List<Subject> GetAllSubjects()
        {
            List<Subject> result = new List<Subject>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("SubjectGetAll", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result.Add(DBAccessExtensions.MapTableEntityTo<Subject>(reader));
                            }
                        }
                    }
                }
            }

            return result;
        }
        public Subject GetSubjectById(int id)
        {
            Subject result = null;

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("SubjectGetById", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result = DBAccessExtensions.MapTableEntityTo<Subject>(reader);
                            }
                        }
                    }
                }
            }

            return result;
        }
        
        #endregion

        #region [WriteMethods]

        public Subject InsertSubject(Subject subject, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("SubjectInsert", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    return InsertSubjectSqlCommand(sqlCommand, subject);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("SubjectInsert", sqlConnection))
                    {
                        return InsertSubjectSqlCommand(sqlCommand, subject);
                    }
                }
            }
        }
        public Subject UpdateSubject(Subject subject, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("SubjectUpdate", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    return UpdateSubjectSqlCommand(sqlCommand, subject);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("SubjectUpdate", sqlConnection))
                    {
                        return UpdateSubjectSqlCommand(sqlCommand, subject);
                    }
                }
            }
        }
        public void DeleteSubject(Subject subject, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("SubjectDelete", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    DeleteSubjectSqlCommand(sqlCommand, subject);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("SubjectDelete", sqlConnection))
                    {
                        DeleteSubjectSqlCommand(sqlCommand, subject);
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

        public Subject InsertSubjectSqlCommand(SqlCommand sqlCommand, Subject subject)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@UserId", subject.UserId);
            sqlCommand.Parameters.AddWithValue("@Name", subject.Name);
            sqlCommand.Parameters.AddWithValue("@CreatedBy", subject.CreatedBy);
            sqlCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

            SqlParameter outputIdParam = new SqlParameter("@Id", SqlDbType.Int);
            outputIdParam.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(outputIdParam);

            SqlParameter outputVersionParam = new SqlParameter("@Version", SqlDbType.Timestamp);
            outputVersionParam.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(outputVersionParam);

            sqlCommand.ExecuteNonQuery();

            subject.Id = Convert.ToInt32(outputIdParam.Value);
            subject.Version = (byte[])(outputVersionParam.Value);

            return subject;
        }

        public Subject UpdateSubjectSqlCommand(SqlCommand sqlCommand, Subject subject)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", subject.Id);
            sqlCommand.Parameters.AddWithValue("@UserId", subject.UserId);
            sqlCommand.Parameters.AddWithValue("@Name", subject.Name);
            sqlCommand.Parameters.AddWithValue("@ModifiedBy", subject.ModifiedBy);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

            SqlParameter outputVersionParam = new SqlParameter("@Version", SqlDbType.Timestamp);
            outputVersionParam.Direction = ParameterDirection.InputOutput;
            outputVersionParam.Value = subject.Version;
            sqlCommand.Parameters.Add(outputVersionParam);

            int result = sqlCommand.ExecuteNonQuery();
            subject.Version = (byte[])(outputVersionParam.Value);

            if (result == 0)
            {
                throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before updating.");
            }

            return subject;
        }

        public void DeleteSubjectSqlCommand(SqlCommand sqlCommand, Subject subject)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", subject.Id);
            sqlCommand.Parameters.AddWithValue("@Version", subject.Version);

            int result = sqlCommand.ExecuteNonQuery();

            if (result == 0)
            {
                throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before deleting.");
            }
        }
        #endregion

    }
}
