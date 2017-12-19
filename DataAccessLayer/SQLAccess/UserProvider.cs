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
    public class UserProvider : IUserInterface
    {
        private readonly string _connectionString = AppSettings.ConnectionString;

        #region [ReadMethods]

        public List<User> GetAllUsers()
        {
            List<User> result = new List<User>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("UserGetAll", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result.Add(DBAccessExtensions.MapTableEntityTo<User>(reader));
                            }
                        }
                    }
                }
            }

            return result;
        }
        public User GetUserById(int id)
        {
            User result = null;

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("UserGetById", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result = DBAccessExtensions.MapTableEntityTo<User>(reader);
                            }
                        }
                    }
                }
            }

            return result;
        }
        public User GetUserByUsername(string username)
        {
            User result = null;

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("UserGetByUsername", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Username", username);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result = DBAccessExtensions.MapTableEntityTo<User>(reader);
                            }
                        }
                    }
                }
            }

            return result;
        }
        public User GetUserByCredentials(string username, string password)
        {
            User result = null;

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("UserGetByCredentials", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Username", username);
                    sqlCommand.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result = DBAccessExtensions.MapTableEntityTo<User>(reader);
                            }
                        }
                    }
                }
            }

            return result;
        }
        public List<string> GetUserRolesByUser(string username)
        {
            List<string> result = new List<string>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("UserRolesGetByUsername", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Username", username);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result.Add(reader.GetString(0));
                            }
                        }
                    }
                }
            }

            return result;
        }
        public List<User> GetAllProfessors()
        {
            List<User> result = new List<User>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("UserGetAllProfessors", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result.Add(DBAccessExtensions.MapTableEntityTo<User>(reader));
                            }
                        }
                    }
                }
            }

            return result;
        }
        #endregion

        #region [WriteMethods]

        public User InsertUser(User user, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("UserInsert", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    return InsertUserSqlCommand(sqlCommand, user);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("UserInsert", sqlConnection))
                    {
                        return InsertUserSqlCommand(sqlCommand, user);
                    }
                }
            }
        }
        public User UpdateUser(User user, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("UserUpdate", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    return UpdateUserSqlCommand(sqlCommand, user);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("UserUpdate", sqlConnection))
                    {
                        return UpdateUserSqlCommand(sqlCommand, user);
                    }
                }
            }
        }
        public void DeleteUser(User user, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("UserDelete", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    DeleteUserSqlCommand(sqlCommand, user);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("UserDelete", sqlConnection))
                    {
                        DeleteUserSqlCommand(sqlCommand, user);
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

        public User InsertUserSqlCommand(SqlCommand sqlCommand, User user)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Name", user.Name);
            sqlCommand.Parameters.AddWithValue("@Surname", user.Surname);
            sqlCommand.Parameters.AddWithValue("@Username", user.Username);
            sqlCommand.Parameters.AddWithValue("@Password", user.Password);
            sqlCommand.Parameters.AddWithValue("@Email", user.Email);

            SqlParameter outputIdParam = new SqlParameter("@Id", SqlDbType.Int);
            outputIdParam.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(outputIdParam);

            SqlParameter outputVersionParam = new SqlParameter("@Version", SqlDbType.Timestamp);
            outputVersionParam.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(outputVersionParam);

            sqlCommand.ExecuteNonQuery();

            user.Id = Convert.ToInt32(outputIdParam.Value);
            user.Version = (byte[])(outputVersionParam.Value);

            return user;
        }

        public User UpdateUserSqlCommand(SqlCommand sqlCommand, User user)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", user.Id);
            sqlCommand.Parameters.AddWithValue("@Name", user.Name);
            sqlCommand.Parameters.AddWithValue("@Surname", user.Surname);
            sqlCommand.Parameters.AddWithValue("@Username", user.Username);
            sqlCommand.Parameters.AddWithValue("@Password", user.Password);
            sqlCommand.Parameters.AddWithValue("@Email", user.Email);

            SqlParameter outputVersionParam = new SqlParameter("@Version", SqlDbType.Timestamp);
            outputVersionParam.Direction = ParameterDirection.InputOutput;
            outputVersionParam.Value = user.Version;
            sqlCommand.Parameters.Add(outputVersionParam);

            int result = sqlCommand.ExecuteNonQuery();
            user.Version = (byte[])(outputVersionParam.Value);

            if (result == 0)
            {
                throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before updating.");
            }

            return user;
        }

        public void DeleteUserSqlCommand(SqlCommand sqlCommand, User user)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", user.Id);
            sqlCommand.Parameters.AddWithValue("@Version", user.Version);

            int result = sqlCommand.ExecuteNonQuery();

            if (result == 0)
            {
                throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before deleting.");
            }
        }
        #endregion

    }
}
