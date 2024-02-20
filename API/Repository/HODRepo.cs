using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using API.Model;
using API.Repository;

namespace API.Repositories
{
    public class HODRepository : IRepository<HOD>
    {
        private readonly SqlConnection connection;

        public HODRepository(SqlConnection connection)
        {
            this.connection = connection;
        }

        public void Add(HOD headOfDepartment)
        {
            string query = "INSERT INTO HOD (UniversityID) VALUES (@UniversityID)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UniversityID", headOfDepartment.UniversityID);
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<HOD> GetAll()
        {
            List<HOD> hods = new List<HOD>();

            string query = "SELECT * FROM HOD";

            SqlCommand command = new SqlCommand(query, connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                foreach (DataRow row in GetDataTable(query).Rows)
                {
                    int UserID = (int)row["UserID"];

                    int UniversityID = (int)row["UniversityID"];

                    hods.Add(new HOD( UserID, UniversityID));
                }
            }

            return hods;
        }

        public HOD GetById(int id)
        {
            string query = $"SELECT * FROM HOD WHERE UserID = @UserID";

            DataRow row = GetDataTable(query).Rows[0];
            int UserID = (int)row["UserID"];
            int UniversityID = (int)row["UniversityID"];
         
            return new HOD(UserID, UniversityID);
        }

        public void Update(HOD entity)
        {
            string query = "UPDATE HOD SET UniversityID = @UniversityID WHERE UserID = @UserID";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UniversityID", entity.UniversityID);
                command.Parameters.AddWithValue("@UserID", entity.UserID);
                command.ExecuteNonQuery();
            }
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
