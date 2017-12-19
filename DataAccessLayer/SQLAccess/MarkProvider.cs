using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Gradebook.DataAccessLayer.Models;
using Gradebook.RepositoryLayer.Interfaces;
using Gradebook.Utilities.Common.Extensions;
using Gradebook.Utilities.Common;
using System.Diagnostics;

namespace Gradebook.DataAccessLayer.SQLAccess.Providers
{
    public class MarkProvider : IMarkInterface
    {
        private readonly string _connectionString = AppSettings.ConnectionString;

        #region [ReadMethods]
        public List<Mark> GetAllMarks()
        {
            List<Mark> result = new List<Mark>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("MarkGetAll", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result.Add(DBAccessExtensions.MapTableEntityTo<Mark>(reader));
                            }
                        }
                    }
                }
            }

            return result;
        }
        public Mark GetMarkById(int id)
        {
            Mark result = null;

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("MarkGetById", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result = DBAccessExtensions.MapTableEntityTo<Mark>(reader);
                            }
                        }
                    }
                }
            }

            return result;
        }
        public List<Mark> GetMarksByMarksId(int id)
        {
            List<Mark> result = new List<Mark>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("MarkGetAllByMarksId", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result.Add(DBAccessExtensions.MapTableEntityTo<Mark>(reader));
                            }
                        }
                    }
                }
            }

            return result;
        }
        public List<String> GetAllMarkTypes()
        {
            List<String> result = new List<String>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("MarkGetAllTypes", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result.Add(reader[0].ToString());
                            }
                        }
                    }
                }
            }

            return result;
        }
        public List<String> GetMarkTypesByMarksId(int id)
        {
            List<String> result = new List<String>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("MarkGetTypesByMarksId", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@MarksId", id);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result.Add(reader[0].ToString());
                            }
                        }
                    }
                }
            }

            return result;
        }
        public decimal GetAverageByPupilId(int id)
        {
            decimal result = 0;

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("MarkGetAverageByPupilId", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@PupilId", id);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                if (reader[0] != null)
                                {
                                    result = Convert.ToDecimal(reader[0]);
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }
        #endregion

        #region [WriteMethods]

        public Mark InsertMark(Mark mark, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("MarkInsert", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    return InsertMarkSqlCommand(sqlCommand, mark);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("MarkInsert", sqlConnection))
                    {
                        return InsertMarkSqlCommand(sqlCommand, mark);
                    }
                }
            }
        }
        public Mark UpdateMark(Mark mark, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("MarkUpdate", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    return UpdateMarkSqlCommand(sqlCommand, mark);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("MarkUpdate", sqlConnection))
                    {
                        return UpdateMarkSqlCommand(sqlCommand, mark);
                    }
                }
            }
        }
        public void DeleteMark(Mark mark, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("MarkDelete", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    DeleteMarkSqlCommand(sqlCommand, mark);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("MarkDelete", sqlConnection))
                    {
                        DeleteMarkSqlCommand(sqlCommand, mark);
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

        public Mark InsertMarkSqlCommand(SqlCommand sqlCommand, Mark mark)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@MarksId", mark.MarksId);
            sqlCommand.Parameters.AddWithValue("@Grade", mark.Grade);
            sqlCommand.Parameters.AddWithValue("@Type", mark.Type);
            sqlCommand.Parameters.AddWithValue("@Important", mark.Important);
            sqlCommand.Parameters.AddWithValue("@Final", mark.Final);
            sqlCommand.Parameters.AddWithValue("@CreatedBy", mark.CreatedBy);
            sqlCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

            SqlParameter outputIdParam = new SqlParameter("@Id", SqlDbType.Int);
            outputIdParam.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(outputIdParam);

            SqlParameter outputVersionParam = new SqlParameter("@Version", SqlDbType.Timestamp);
            outputVersionParam.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(outputVersionParam);

            sqlCommand.ExecuteNonQuery();

            mark.Id = Convert.ToInt32(outputIdParam.Value);
            mark.Version = (byte[])(outputVersionParam.Value);

            return mark;
        }

        public Mark UpdateMarkSqlCommand(SqlCommand sqlCommand, Mark mark)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", mark.Id);
            sqlCommand.Parameters.AddWithValue("@MarksId", mark.MarksId);
            sqlCommand.Parameters.AddWithValue("@Grade", mark.Grade);
            sqlCommand.Parameters.AddWithValue("@Type", mark.Type);
            sqlCommand.Parameters.AddWithValue("@Important", mark.Important);
            sqlCommand.Parameters.AddWithValue("@Final", mark.Final);
            sqlCommand.Parameters.AddWithValue("@ModifiedBy", mark.ModifiedBy);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

            SqlParameter outputVersionParam = new SqlParameter("@Version", SqlDbType.Timestamp);
            outputVersionParam.Direction = ParameterDirection.InputOutput;
            outputVersionParam.Value = mark.Version;
            sqlCommand.Parameters.Add(outputVersionParam);

            int result = sqlCommand.ExecuteNonQuery();
            mark.Version = (byte[])(outputVersionParam.Value);

            if (result == 0)
            {
                throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before updating.");
            }

            return mark;
        }

        public void DeleteMarkSqlCommand(SqlCommand sqlCommand, Mark mark)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", mark.Id);
            sqlCommand.Parameters.AddWithValue("@Version", mark.Version);

            int result = sqlCommand.ExecuteNonQuery();

            if (result == 0)
            {
                throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before deleting.");
            }
        }
        #endregion

    }
}
