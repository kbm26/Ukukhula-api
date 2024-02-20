using System;
using System.Collections.Generic;
using System.Data;
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

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FirstName", user.FirstName);
            command.Parameters.AddWithValue("@LastName", user.LastName);
            command.Parameters.AddWithValue("@ContactID", user.ContactID);
            command.Parameters.AddWithValue("@RoleID", user.RoleID);

            command.ExecuteNonQuery();

        }

        public IEnumerable<User> GetAll()
        {
            List<User> users = new List<User>();

            string query = "SELECT * FROM Users";

            SqlCommand command = new SqlCommand(query, connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                foreach (DataRow row in GetDataTable(query).Rows)
                {
                    string firstName = row["Firstname"].ToString();
                    string lastName = row["Lastname"].ToString();
                    int ContactID = (int)row["ContactID"];
                    int RoleID = (int)row["RoleID"];

                    users.Add(new User(firstName, lastName, ContactID, RoleID));
                }
            }

            return users;
        }


        public User GetById(int userId)
        {
            string query = $"SELECT * FROM User WHERE UserID = @UserID";

            DataRow row = GetDataTable(query).Rows[0];
            _ = (int)row["UserID"];
            string FirstName = row["FirstName"].ToString();
            string LastName = row["LastName"].ToString();
            int ContactID = (int)row["ContactID"];
            int RoleID = (int)row["RoleID"];
            User user = new User(FirstName, LastName, ContactID, RoleID);
            return user;
        }

        public void Update(User user)
        {
            string query = "UPDATE Users SET FirstName = @FirstName, " +
                           "LastName = @LastName, " +
                           "ContactID = @ContactID, " +
                           "RoleID = @RoleID " +
                           "WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FirstName", user.FirstName);
            command.Parameters.AddWithValue("@LastName", user.LastName);
            command.Parameters.AddWithValue("@ContactID", user.ContactID);
            command.Parameters.AddWithValue("@RoleID", user.RoleID);
            command.Parameters.AddWithValue("@UserID", user.UserID);

            command.ExecuteNonQuery();

        }

        private DataTable GetDataTable(string query)
        {
            DataTable dataTable = new DataTable();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }
    }
}
