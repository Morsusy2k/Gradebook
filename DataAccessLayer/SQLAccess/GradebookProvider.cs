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
    public class GradebookProvider : IGradebookInterface
    {
        private readonly string _connectionString = AppSettings.ConnectionString;

        #region [ReadMethods]

        public List<Gbook> GetAllGradebooks()
        {
            List<Gbook> result = new List<Gbook>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("GradebookGetAll", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result.Add(DBAccessExtensions.MapTableEntityTo<Gbook>(reader));
                            }
                        }
                    }
                }
            }

            return result;
        }
        public Gbook GetGradebookById(int id)
        {
            Gbook result = null;

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("GradebookGetById", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result = DBAccessExtensions.MapTableEntityTo<Gbook>(reader);
                            }
                        }
                    }
                }
            }

            return result;
        }

        public Gbook GetGradebookByClassId(int id)
        {
            Gbook result = null;

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("GradebookGetByClassId", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@ClassId", id);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result = DBAccessExtensions.MapTableEntityTo<Gbook>(reader);
                            }
                        }
                    }
                }
            }

            return result;
        }

        #endregion

        #region [WriteMethods]

        public Gbook InsertGradebook(Gbook gradebook, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("GradebookInsert", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    return InsertGradebookSqlCommand(sqlCommand, gradebook);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("GradebookInsert", sqlConnection))
                    {
                        return InsertGradebookSqlCommand(sqlCommand, gradebook);
                    }
                }
            }
        }
        public Gbook UpdateGradebook(Gbook gradebook, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("GradebookUpdate", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    return UpdateGradebookSqlCommand(sqlCommand, gradebook);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("GradebookUpdate", sqlConnection))
                    {
                        return UpdateGradebookSqlCommand(sqlCommand, gradebook);
                    }
                }
            }
        }
        public void DeleteGradebook(Gbook gradebook, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("GradebookDelete", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    DeleteGradebookSqlCommand(sqlCommand, gradebook);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("GradebookDelete", sqlConnection))
                    {
                        DeleteGradebookSqlCommand(sqlCommand, gradebook);
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

        public Gbook InsertGradebookSqlCommand(SqlCommand sqlCommand, Gbook gradebook)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@PClassId", gradebook.PClassId);
            sqlCommand.Parameters.AddWithValue("@SchoolYearStart", gradebook.SchoolYearStart);
            sqlCommand.Parameters.AddWithValue("@SchoolYearEnd", gradebook.SchoolYearEnd);
            sqlCommand.Parameters.AddWithValue("@Editable", gradebook.Editable);
            sqlCommand.Parameters.AddWithValue("@CreatedBy", gradebook.CreatedBy);
            sqlCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

            SqlParameter outputIdParam = new SqlParameter("@Id", SqlDbType.Int);
            outputIdParam.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(outputIdParam);

            SqlParameter outputVersionParam = new SqlParameter("@Version", SqlDbType.Timestamp);
            outputVersionParam.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(outputVersionParam);

            sqlCommand.ExecuteNonQuery();

            gradebook.Id = Convert.ToInt32(outputIdParam.Value);
            gradebook.Version = (byte[])(outputVersionParam.Value);

            return gradebook;
        }

        public Gbook UpdateGradebookSqlCommand(SqlCommand sqlCommand, Gbook gradebook)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", gradebook.Id);
            sqlCommand.Parameters.AddWithValue("@PClassId", gradebook.PClassId);
            sqlCommand.Parameters.AddWithValue("@SchoolYearStart", gradebook.SchoolYearStart);
            sqlCommand.Parameters.AddWithValue("@SchoolYearEnd", gradebook.SchoolYearEnd);
            sqlCommand.Parameters.AddWithValue("@Editable", gradebook.Editable);
            sqlCommand.Parameters.AddWithValue("@ModifiedBy", gradebook.ModifiedBy);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

            SqlParameter outputVersionParam = new SqlParameter("@Version", SqlDbType.Timestamp);
            outputVersionParam.Direction = ParameterDirection.InputOutput;
            outputVersionParam.Value = gradebook.Version;
            sqlCommand.Parameters.Add(outputVersionParam);

            int result = sqlCommand.ExecuteNonQuery();
            gradebook.Version = (byte[])(outputVersionParam.Value);

            if (result == 0)
            {
                throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before updating.");
            }

            return gradebook;
        }

        public void DeleteGradebookSqlCommand(SqlCommand sqlCommand, Gbook gradebook)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", gradebook.Id);
            sqlCommand.Parameters.AddWithValue("@Version", gradebook.Version);

            int result = sqlCommand.ExecuteNonQuery();

            if (result == 0)
            {
                throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before deleting.");
            }
        }
        #endregion

    }
}
