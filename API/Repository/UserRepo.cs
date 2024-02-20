using System.Data;
using System.Data.SqlClient;
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
            string query = "SELECT * FROM Users";

            foreach (DataRow row in GetDataTable(query).Rows)
            {
                int UserID = int.Parse(row["UserID"].ToString());
                int RoleID = int.Parse(row["RoleID"].ToString());
                int ContactID = int.Parse(row["ContactID"].ToString());
                string FirstName = row["FirstName"].ToString();
                string LastName = row["LastName"].ToString();
                User user = new User(FirstName, LastName, ContactID, RoleID);
                user.UserID = UserID;
                yield return user;
            }


        }

        public User GetById(int userId)
        {
            string query = $"SELECT * FROM Users WHERE UserID = {userId}";
            DataRow row = GetDataTable(query).Rows[0];
            int RoleID = int.Parse(row["RoleID"].ToString());
            int ContactID = int.Parse(row["ContactID"].ToString());
            string FirstName = row["FirstName"].ToString();
            string LastName = row["LastName"].ToString();
            return new User(FirstName, LastName, ContactID, RoleID);
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
