using System;
using System.Collections.Generic;
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

        public void Add(HOD hod)
        {
            string query = "INSERT INTO HODs (UniversityID) VALUES (@UniversityID)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UniversityID", hod.UniversityID);
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<HOD> GetAll()
        {
            List<HOD> hods = new List<HOD>();
            string query = "SELECT * FROM HODs";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    foreach (var row in reader)
                    {
                        HOD hod = new HOD
                        {
                            UserID = (int)reader["UserID"],
                            UniversityID = (int)reader["UniversityID"]
                        };
                        hods.Add(hod);
                    }
                }
            }
            return hods;
        }

        public HOD GetById(int id)
        {
            string query = "SELECT * FROM HODs WHERE UserID = @UserID";
            HOD hod = new HOD();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserID", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    foreach (var row in reader)
                    {
                        if (reader.Read())
                        {
                            hod = new HOD
                            {
                                UserID = (int)reader["UserID"],
                                UniversityID = (int)reader["UniversityID"]
                            };
                        }
                    }
                }
            }

            return hod;
        }

        public void Update(HOD entity)
        {
            string query = "UPDATE HODs SET UniversityID = @UniversityID WHERE UserID = @UserID";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UniversityID", entity.UniversityID);
                command.Parameters.AddWithValue("@UserID", entity.UserID);
                command.ExecuteNonQuery();
            }
        }
    }
}
