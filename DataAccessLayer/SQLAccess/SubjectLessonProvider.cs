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
    public class SubjectLessonProvider : ISubjectLessonInterface
    {
        private readonly string _connectionString = AppSettings.ConnectionString;

        #region [ReadMethods]

        public List<SubjectLesson> GetAllSubjectLessons()
        {
            List<SubjectLesson> result = new List<SubjectLesson>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("SubjectLessonGetAll", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result.Add(DBAccessExtensions.MapTableEntityTo<SubjectLesson>(reader));
                            }
                        }
                    }
                }
            }

            return result;
        }
        public SubjectLesson GetSubjectLessonById(int id)
        {
            SubjectLesson result = null;

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("SubjectLessonGetById", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result = DBAccessExtensions.MapTableEntityTo<SubjectLesson>(reader);
                            }
                        }
                    }
                }
            }

            return result;
        }
        #endregion

        #region [WriteMethods]

        public SubjectLesson InsertSubjectLesson(SubjectLesson lesson, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("SubjectLessonInsert", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    return InsertSubjectLessonSqlCommand(sqlCommand, lesson);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("SubjectLessonInsert", sqlConnection))
                    {
                        return InsertSubjectLessonSqlCommand(sqlCommand, lesson);
                    }
                }
            }
        }
        public SubjectLesson UpdateSubjectLesson(SubjectLesson lesson, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("SubjectLessonUpdate", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    return UpdateSubjectLessonSqlCommand(sqlCommand, lesson);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("SubjectLessonUpdate", sqlConnection))
                    {
                        return UpdateSubjectLessonSqlCommand(sqlCommand, lesson);
                    }
                }
            }
        }
        public void DeleteSubjectLesson(SubjectLesson lesson, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("SubjectLessonDelete", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    DeleteSubjectLessonSqlCommand(sqlCommand, lesson);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("SubjectLessonDelete", sqlConnection))
                    {
                        DeleteSubjectLessonSqlCommand(sqlCommand, lesson);
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

        public SubjectLesson InsertSubjectLessonSqlCommand(SqlCommand sqlCommand, SubjectLesson lesson)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@GradebookId", lesson.GradebookId);
            sqlCommand.Parameters.AddWithValue("@SubjectId", lesson.SubjectId);
            sqlCommand.Parameters.AddWithValue("@LessonTheme", lesson.LessonTheme);
            sqlCommand.Parameters.AddWithValue("@Date", lesson.Date);
            sqlCommand.Parameters.AddWithValue("@TimeOfLesson", lesson.TimeOfLesson);
            sqlCommand.Parameters.AddWithValue("@CreatedBy", lesson.CreatedBy);
            sqlCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

            SqlParameter outputIdParam = new SqlParameter("@Id", SqlDbType.Int);
            outputIdParam.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(outputIdParam);

            SqlParameter outputVersionParam = new SqlParameter("@Version", SqlDbType.Timestamp);
            outputVersionParam.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(outputVersionParam);

            sqlCommand.ExecuteNonQuery();

            lesson.Id = Convert.ToInt32(outputIdParam.Value);
            lesson.Version = (byte[])(outputVersionParam.Value);

            return lesson;
        }

        public SubjectLesson UpdateSubjectLessonSqlCommand(SqlCommand sqlCommand, SubjectLesson lesson)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", lesson.Id);
            sqlCommand.Parameters.AddWithValue("@GradebookId", lesson.GradebookId);
            sqlCommand.Parameters.AddWithValue("@SubjectId", lesson.SubjectId);
            sqlCommand.Parameters.AddWithValue("@LessonTheme", lesson.LessonTheme);
            sqlCommand.Parameters.AddWithValue("@Date", lesson.Date);
            sqlCommand.Parameters.AddWithValue("@TimeOfLesson", lesson.TimeOfLesson);
            sqlCommand.Parameters.AddWithValue("@ModifiedBy", lesson.ModifiedBy);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

            SqlParameter outputVersionParam = new SqlParameter("@Version", SqlDbType.Timestamp);
            outputVersionParam.Direction = ParameterDirection.InputOutput;
            outputVersionParam.Value = lesson.Version;
            sqlCommand.Parameters.Add(outputVersionParam);

            int result = sqlCommand.ExecuteNonQuery();
            lesson.Version = (byte[])(outputVersionParam.Value);

            if (result == 0)
            {
                throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before updating.");
            }

            return lesson;
        }

        public void DeleteSubjectLessonSqlCommand(SqlCommand sqlCommand, SubjectLesson lesson)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", lesson.Id);
            sqlCommand.Parameters.AddWithValue("@Version", lesson.Version);

            int result = sqlCommand.ExecuteNonQuery();

            if (result == 0)
            {
                throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before deleting.");
            }
        }
        #endregion

    }
}
