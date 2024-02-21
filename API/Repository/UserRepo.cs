using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Xml.Linq;
using API.Model;

namespace API.Repository
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
            string query = "INSERT INTO [dbo].[User] (FirstName, LastName, ContactID, RoleID)" +
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
            string query = "SELECT * FROM [dbo].[User];";

            foreach (DataRow row in GetDataTable(query).Rows)
            {
                int UserID = (int)row["UserID"];
                string FirstName = row["FirstName"].ToString();
                string LastName = row["LastName"].ToString();
                int ContactID = (int)row["ContactID"];
                int RoleID = (int)row["RoleID"];
                User user = new User( FirstName, LastName, ContactID, RoleID);
                user.UserID = (int)row["UserID"];
                yield return user;
            }
        }
        public User GetById(int id)
        {
            string query = $"SELECT * FROM [dbo].[User] WHERE UserID = {id}";

            DataRow row = GetDataTable(query).Rows[0];
            int UserID = (int)row["UserID"];
            string FirstName = row["FirstName"].ToString();
            string LastName = row["LastName"].ToString();
            int ContactID = (int) row["ContactID"];
            int RoleID = (int) row["RoleID"];
            User user = new User(FirstName, LastName, ContactID, RoleID);
            user.UserID = (int)row["UserID"];
            return user;
        }

        public void Update(User newEntity)
        {
            string query = @"UPDATE [dbo].[User] SET FirstName = @FirstName, LastName = @LastName,
                            ContactID = @ContactID, RoleID = @RoleID 
                            WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            
            command.Parameters.AddWithValue("@FirstName", newEntity.FirstName);
            command.Parameters.AddWithValue("@LastName", newEntity.LastName);
            command.Parameters.AddWithValue("@ContactID", newEntity.ContactID);
            command.Parameters.AddWithValue("@RoleID", newEntity.RoleID);
            command.Parameters.AddWithValue("@UserID", newEntity.UserID);

            command.ExecuteNonQuery();
        }

        public DataTable GetDataTable(string query)
        {
            DataTable dataTable = new DataTable();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}


