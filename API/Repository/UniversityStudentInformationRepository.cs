using API.Model;
using System.Data;
using System.Data.SqlClient;

namespace API.Repository
{
    public class UniversityStudentInformationRepository(SqlConnection connection) : IRepository<UniversityStudentInformation>
    {
        public void Add(UniversityStudentInformation entity)
        {
            string query = @"INSERT INTO UniversityStudentInformation (UniversityID, StudentID) 
                            VALUES (@UniversityID, @StudentID)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@StudentID", entity.StudentID);
            command.Parameters.AddWithValue("@UniversityID", entity.UniversityID);
            command.ExecuteNonQuery();
        }

        public IEnumerable<UniversityStudentInformation> GetAll()
        {
            string query = $"SELECT * FROM UniversityStudentInformation";

            foreach (DataRow row in GetDataTable(query).Rows)
            {

                int UniversityID = int.Parse(row["UniversityID"].ToString());
                int StudentID = int.Parse(row["StudentID"].ToString());
                UniversityStudentInformation universityStudentInformation = new UniversityStudentInformation(UniversityID, StudentID);
                universityStudentInformation.UniversityID = int.Parse(row["UniversityID"].ToString());
                yield return universityStudentInformation;
            }
        }

        public UniversityStudentInformation GetById(int id)
        {
            string query = $"SELECT * FROM UniversityStudentInformation WHERE StudentID = {id}";

            DataRow row = GetDataTable(query).Rows[0];
            int UniversityID = int.Parse(row["UniversityID"].ToString());
            int StudentID = int.Parse(row["StudentID"].ToString());
            return new UniversityStudentInformation(UniversityID, StudentID);
        }

        public void Update(UniversityStudentInformation newEntity)
        {
            string query = @"UPDATE UniversityStudentInformation SET StudentID = @StudentID WHERE UniversityID = @UniversityID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@StudentID", newEntity.StudentID);
            command.Parameters.AddWithValue("@UniversitID", newEntity.UniversityID);
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
