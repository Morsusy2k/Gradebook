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
    public class RoleProvider : IRoleInterface
    {
        private readonly string _connectionString = AppSettings.ConnectionString;

        #region [ReadMethods]

        public List<Role> GetAllRoles()
        {
            List<Role> result = new List<Role>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("RoleGetAll", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result.Add(DBAccessExtensions.MapTableEntityTo<Role>(reader));
                            }
                        }
                    }
                }
            }

            return result;
        }
        public Role GetRoleById(int id)
        {
            Role result = null;

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("RoleGetById", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result = DBAccessExtensions.MapTableEntityTo<Role>(reader);
                            }
                        }
                    }
                }
            }

            return result;
        }
        public List<Role> GetAllRolesByUserId(int id)
        {
            List<Role> result = new List<Role>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("RoleGetByUserId", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@UserId", id);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result.Add(DBAccessExtensions.MapTableEntityTo<Role>(reader));
                            }
                        }
                    }
                }
            }

            return result;
        }

        #endregion

        #region [WriteMethods]

        public Role InsertRole(Role role, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("RoleInsert", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    return InsertRoleSqlCommand(sqlCommand, role);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("RoleInsert", sqlConnection))
                    {
                        return InsertRoleSqlCommand(sqlCommand, role);
                    }
                }
            }
        }
        
        public void DeleteRole(Role role, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("RoleDelete", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    DeleteRoleSqlCommand(sqlCommand, role);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("RoleDelete", sqlConnection))
                    {
                        DeleteRoleSqlCommand(sqlCommand, role);
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

        public Role InsertRoleSqlCommand(SqlCommand sqlCommand, Role role)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Name", role.Name);

            SqlParameter outputIdParam = new SqlParameter("@Id", SqlDbType.Int);
            outputIdParam.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(outputIdParam);

            sqlCommand.ExecuteNonQuery();

            role.Id = Convert.ToInt32(outputIdParam.Value);

            return role;
        }

        public void DeleteRoleSqlCommand(SqlCommand sqlCommand, Role role)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", role.Id);

            int result = sqlCommand.ExecuteNonQuery();

            if (result == 0)
            {
                throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before deleting.");
            }
        }
        #endregion

        #region [UserRoleReadMethods]
        public List<UserRole> GetAllUserRoles()
        {
            List<UserRole> result = new List<UserRole>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("UserRoleGetAll", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result.Add(DBAccessExtensions.MapTableEntityTo<UserRole>(reader));
                            }
                        }
                    }
                }
            }

            return result;
        }
        public UserRole GetUserRoleById(int id)
        {
            UserRole result = null;

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("UserRoleGetById", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result = DBAccessExtensions.MapTableEntityTo<UserRole>(reader);
                            }
                        }
                    }
                }
            }

            return result;
        }

        public List<UserRole> GetUserRolesByUserId(int id)
        {
            List<UserRole> result = new List<UserRole>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("UserRolesGetByUserId", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result.Add(DBAccessExtensions.MapTableEntityTo<UserRole>(reader));
                            }
                        }
                    }
                }
            }

            return result;
        }
        #endregion

        #region [UserRoleWriteMethods]

        public void InsertUserRole(User editor, Role role, User user, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("UserRoleInsert", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    InsertUserRoleSqlCommand(sqlCommand, editor, role, user);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("UserRoleInsert", sqlConnection))
                    {
                        InsertUserRoleSqlCommand(sqlCommand, editor, role, user);
                    }
                }
            }
        }

        public void UpdateUserRole(User editor, Role role, User user, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("UserRoleUpdate", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    UpdateUserRoleSqlCommand(sqlCommand, editor, role, user);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("UserRoleUpdate", sqlConnection))
                    {
                        UpdateUserRoleSqlCommand(sqlCommand, editor, role, user);
                    }
                }
            }
        }

        public void DeleteUserRole(UserRole userRole, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("UserRoleDelete", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    DeleteUserRoleSqlCommand(sqlCommand, userRole);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("UserRoleDelete", sqlConnection))
                    {
                        DeleteUserRoleSqlCommand(sqlCommand, userRole);
                    }
                }
            }
        }

        public void DeleteUserRolesByUser(User user, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("RoleDeleteAllByUserId", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    DeleteUserRolesByUserSqlCommand(sqlCommand, user);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("RoleDeleteAllByUserId", sqlConnection))
                    {
                        DeleteUserRolesByUserSqlCommand(sqlCommand, user);
                    }
                }
            }
        }
        #endregion

        #region [UserRoleSqlCommandMethods]

        public void InsertUserRoleSqlCommand(SqlCommand sqlCommand, User editor, Role role, User user)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@UserId", user.Id);
            sqlCommand.Parameters.AddWithValue("@RoleId", role.Id);
            sqlCommand.Parameters.AddWithValue("@CreatedBy", editor.Id);
            sqlCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

            SqlParameter outputIdParam = new SqlParameter("@Id", SqlDbType.Int);
            outputIdParam.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(outputIdParam);

            SqlParameter outputVersionParam = new SqlParameter("@Version", SqlDbType.Timestamp);
            outputVersionParam.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(outputVersionParam);

            sqlCommand.ExecuteNonQuery();

            user.Id = Convert.ToInt32(outputIdParam.Value);
            user.Version = (byte[])(outputVersionParam.Value);
        }

        public void UpdateUserRoleSqlCommand(SqlCommand sqlCommand, User editor, Role role, User user)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", user.Id);
            sqlCommand.Parameters.AddWithValue("@UserId", user.Id);
            sqlCommand.Parameters.AddWithValue("@RoleId", role.Id);
            sqlCommand.Parameters.AddWithValue("@ModifiedBy", editor.Id);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);

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
        }

        public void DeleteUserRoleSqlCommand(SqlCommand sqlCommand, UserRole userRole)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", userRole.Id);
            sqlCommand.Parameters.AddWithValue("@Version", userRole.Version);

            int result = sqlCommand.ExecuteNonQuery();

            if (result == 0)
            {
                throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before deleting.");
            }
        }

        public void DeleteUserRolesByUserSqlCommand(SqlCommand sqlCommand, User user)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@UserId", user.Id);

            int result = sqlCommand.ExecuteNonQuery();
        }
        #endregion
    }
}
