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
            string query = "INSERT INTO HOD " +
                "SET UserID = @UserID, " +
                "WHERE UniversityID = @UniversityID";



            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.AddWithValue("@UserID", headOfDepartment.UserID);
                command.Parameters.AddWithValue("@UniversityID", headOfDepartment.UniversityID);

                command.ExecuteNonQuery();

            }
        }

        public IEnumerable<HOD> GetAll()
        {
            string query = $"SELECT * FROM HOD";

            foreach (DataRow row in GetDataTable(query).Rows)
            {
                int UniversityID = int.Parse(row["UniversityID"].ToString());
                int UserID = int.Parse(row["UserID"].ToString());
                HOD hod = new HOD(UniversityID, UserID);
                hod.UniversityID = int.Parse(row["UniversityID"].ToString());
                yield return hod;
            }
        }

        public HOD GetById(int id)
        {
            string query = $"SELECT * FROM HOD WHERE UserID = @UserID";

            DataRow row = GetDataTable(query).Rows[0];
            int UniversityID = (int)row["UniversityID"];
            int UserID = (int)row["UserID"];
            return new HOD(UniversityID, UserID);
        }

        public void Update(HOD newEntity)
        {
            string query = @"UPDATE HOD, " +
                    "SET UserID = @UserID, " +                       
                    "WHERE UniversityID = @UniversityID";

            SqlCommand command = new SqlCommand(query, connection);

           
            command.Parameters.AddWithValue("@UserID", newEntity.UserID);
            command.Parameters.AddWithValue("@UniversityID", newEntity.UniversityID);
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

