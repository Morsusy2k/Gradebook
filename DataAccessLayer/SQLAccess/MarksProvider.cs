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
    public class MarksProvider : IMarksInterface
    {
        private readonly string _connectionString = AppSettings.ConnectionString;

        #region [ReadMethods]

        public List<Marks> GetAllMarks()
        {
            List<Marks> result = new List<Marks>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("MarksGetAll", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result.Add(DBAccessExtensions.MapTableEntityTo<Marks>(reader));
                            }
                        }
                    }
                }
            }

            return result;
        }
        public Marks GetMarksById(int id)
        {
            Marks result = null;

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("MarksGetById", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result = DBAccessExtensions.MapTableEntityTo<Marks>(reader);
                            }
                        }
                    }
                }
            }

            return result;
        }
        public List<Marks> GetMarksByPupilId(int id)
        {
            List<Marks> result = new List<Marks>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("MarksGetAllByPupilId", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result.Add(DBAccessExtensions.MapTableEntityTo<Marks>(reader));
                            }
                        }
                    }
                }
            }

            return result;
        }
        public Marks GetMarksPupilIdAndSubjectId(int pupilId, int subjectId)
        {
            Marks result = null;

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("MarksGetByPupilIdAndSubjectId", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@PupilId", pupilId);
                    sqlCommand.Parameters.AddWithValue("@SubjectId", subjectId);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result = DBAccessExtensions.MapTableEntityTo<Marks>(reader);
                            }
                        }
                    }
                }
            }

            return result;
        }
        #endregion

        #region [WriteMethods]

        public Marks InsertMarks(Marks marks, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("MarksInsert", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    return InsertMarksSqlCommand(sqlCommand, marks);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("MarksInsert", sqlConnection))
                    {
                        return InsertMarksSqlCommand(sqlCommand, marks);
                    }
                }
            }
        }
        public Marks UpdateMarks(Marks marks, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("MarksUpdate", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    return UpdateMarksSqlCommand(sqlCommand, marks);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("MarksUpdate", sqlConnection))
                    {
                        return UpdateMarksSqlCommand(sqlCommand, marks);
                    }
                }
            }
        }
        public void DeleteMarks(Marks marks, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("MarksDelete", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    DeleteMarksSqlCommand(sqlCommand, marks);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("MarksDelete", sqlConnection))
                    {
                        DeleteMarksSqlCommand(sqlCommand, marks);
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

        public Marks InsertMarksSqlCommand(SqlCommand sqlCommand, Marks marks)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@PupilId", marks.PupilId);
            sqlCommand.Parameters.AddWithValue("@SubjectId", marks.SubjectId);
            sqlCommand.Parameters.AddWithValue("@FinalMark", marks.FinalMark);
            sqlCommand.Parameters.AddWithValue("@CreatedBy", marks.CreatedBy);
            sqlCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

            SqlParameter outputIdParam = new SqlParameter("@Id", SqlDbType.Int);
            outputIdParam.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(outputIdParam);

            SqlParameter outputVersionParam = new SqlParameter("@Version", SqlDbType.Timestamp);
            outputVersionParam.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(outputVersionParam);

            sqlCommand.ExecuteNonQuery();

            marks.Id = Convert.ToInt32(outputIdParam.Value);
            marks.Version = (byte[])(outputVersionParam.Value);

            return marks;
        }

        public Marks UpdateMarksSqlCommand(SqlCommand sqlCommand, Marks marks)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", marks.Id);
            sqlCommand.Parameters.AddWithValue("@PupilId", marks.PupilId);
            sqlCommand.Parameters.AddWithValue("@SubjectId", marks.SubjectId);
            sqlCommand.Parameters.AddWithValue("@FinalMark", marks.FinalMark);
            sqlCommand.Parameters.AddWithValue("@ModifiedBy", marks.ModifiedBy);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

            SqlParameter outputVersionParam = new SqlParameter("@Version", SqlDbType.Timestamp);
            outputVersionParam.Direction = ParameterDirection.InputOutput;
            outputVersionParam.Value = marks.Version;
            sqlCommand.Parameters.Add(outputVersionParam);

            int result = sqlCommand.ExecuteNonQuery();
            marks.Version = (byte[])(outputVersionParam.Value);

            if (result == 0)
            {
                throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before updating.");
            }

            return marks;
        }

        public void DeleteMarksSqlCommand(SqlCommand sqlCommand, Marks marks)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", marks.Id);
            sqlCommand.Parameters.AddWithValue("@Version", marks.Version);

            int result = sqlCommand.ExecuteNonQuery();

            if (result == 0)
            {
                throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before deleting.");
            }
        }
        #endregion

    }
}
