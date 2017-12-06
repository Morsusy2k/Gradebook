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
    public class PClassProvider : IPClassInterface
    {
        private readonly string _connectionString = AppSettings.ConnectionString;

        #region [ReadMethods]

        public List<PClass> GetAllPClasses()
        {
            List<PClass> result = new List<PClass>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("PClassGetAll", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result.Add(DBAccessExtensions.MapTableEntityTo<PClass>(reader));
                            }
                        }
                    }
                }
            }

            return result;
        }
        public PClass GetPClassById(int id)
        {
            PClass result = null;

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("PClassGetById", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result = DBAccessExtensions.MapTableEntityTo<PClass>(reader);
                            }
                        }
                    }
                }
            }

            return result;
        }
        
        #endregion

        #region [WriteMethods]

        public PClass InsertPClass(PClass pclass, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("PClassInsert", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    return InsertPClassSqlCommand(sqlCommand, pclass);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("PClassInsert", sqlConnection))
                    {
                        return InsertPClassSqlCommand(sqlCommand, pclass);
                    }
                }
            }
        }
        public PClass UpdatePClass(PClass pclass, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("PClassUpdate", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    return UpdatePClassSqlCommand(sqlCommand, pclass);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("PClassUpdate", sqlConnection))
                    {
                        return UpdatePClassSqlCommand(sqlCommand, pclass);
                    }
                }
            }
        }
        public void DeletePClass(PClass pclass, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("PClassDelete", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    DeletePClassSqlCommand(sqlCommand, pclass);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("PClassDelete", sqlConnection))
                    {
                        DeletePClassSqlCommand(sqlCommand, pclass);
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

        public PClass InsertPClassSqlCommand(SqlCommand sqlCommand, PClass pclass)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@UserId", pclass.UserId);
            sqlCommand.Parameters.AddWithValue("@FieldOfStudyId", pclass.FieldOfStudyId);
            sqlCommand.Parameters.AddWithValue("@Generation", pclass.Generation);
            sqlCommand.Parameters.AddWithValue("@Year", pclass.Year);
            sqlCommand.Parameters.AddWithValue("@PClassIndex", pclass.PClassIndex);
            sqlCommand.Parameters.AddWithValue("@CreatedBy", pclass.CreatedBy);
            sqlCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

            SqlParameter outputIdParam = new SqlParameter("@Id", SqlDbType.Int);
            outputIdParam.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(outputIdParam);

            SqlParameter outputVersionParam = new SqlParameter("@Version", SqlDbType.Timestamp);
            outputVersionParam.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(outputVersionParam);

            sqlCommand.ExecuteNonQuery();

            pclass.Id = Convert.ToInt32(outputIdParam.Value);
            pclass.Version = (byte[])(outputVersionParam.Value);

            return pclass;
        }

        public PClass UpdatePClassSqlCommand(SqlCommand sqlCommand, PClass pclass)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", pclass.Id);
            sqlCommand.Parameters.AddWithValue("@UserId", pclass.UserId);
            sqlCommand.Parameters.AddWithValue("@FieldOfStodyId", pclass.FieldOfStudyId);
            sqlCommand.Parameters.AddWithValue("@Generation", pclass.Generation);
            sqlCommand.Parameters.AddWithValue("@Year", pclass.Year);
            sqlCommand.Parameters.AddWithValue("@PClassIndex", pclass.PClassIndex);
            sqlCommand.Parameters.AddWithValue("@ModifiedBy", pclass.ModifiedBy);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

            SqlParameter outputVersionParam = new SqlParameter("@Version", SqlDbType.Timestamp);
            outputVersionParam.Direction = ParameterDirection.InputOutput;
            outputVersionParam.Value = pclass.Version;
            sqlCommand.Parameters.Add(outputVersionParam);

            int result = sqlCommand.ExecuteNonQuery();
            pclass.Version = (byte[])(outputVersionParam.Value);

            if (result == 0)
            {
                throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before updating.");
            }

            return pclass;
        }

        public void DeletePClassSqlCommand(SqlCommand sqlCommand, PClass pclass)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", pclass.Id);
            sqlCommand.Parameters.AddWithValue("@Version", pclass.Version);

            int result = sqlCommand.ExecuteNonQuery();

            if (result == 0)
            {
                throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before deleting.");
            }
        }
        #endregion

    }
}
