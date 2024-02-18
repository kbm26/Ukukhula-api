using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using API.Model;
using API.Repository;

namespace API.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly SqlConnection connection;

        public UserRepository(SqlConnection connection)
        {
            this.connection = connection;
        }

        public void Add(User user)
        {
            string query = "INSERT INTO Users (FirstName, LastName, ContactID, RoleID) " +
                           "VALUES (@FirstName, @LastName, @ContactID, @RoleID)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@FirstName", user.FirstName);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@ContactID", user.ContactID);
                command.Parameters.AddWithValue("@RoleID", user.RoleID);

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<User> GetAll()
        {
            List<User> users = new List<User>();

            string query = "SELECT * FROM Users";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User user = new User
                        {
                            UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            ContactID = reader.GetInt32(reader.GetOrdinal("ContactID")),
                            RoleID = reader.GetInt32(reader.GetOrdinal("RoleID"))
                        };

                        users.Add(user);
                    }
                }
            }

            return users;
        }

        public User GetById(int userId)
        {
            User user = null;

            string query = "SELECT * FROM Users WHERE UserID = @UserID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserID", userId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new User
                        {
                            UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            ContactID = reader.GetInt32(reader.GetOrdinal("ContactID")),
                            RoleID = reader.GetInt32(reader.GetOrdinal("RoleID"))
                        };
                    }
                }
            }

            return user;
        }

        public void Update(User user)
        {
            string query = "UPDATE Users SET FirstName = @FirstName, " +
                           "LastName = @LastName, " +
                           "ContactID = @ContactID, " +
                           "RoleID = @RoleID " +
                           "WHERE UserID = @UserID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@FirstName", user.FirstName);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@ContactID", user.ContactID);
                command.Parameters.AddWithValue("@RoleID", user.RoleID);
                command.Parameters.AddWithValue("@UserID", user.UserID);

                command.ExecuteNonQuery();
            }
        }
    }
}
