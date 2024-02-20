using API.Model;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;

namespace API.Repository
{
    public class StudentApplicationRepository : IRepository<StudentApplication>
    {
        SqlConnection connection;
        public StudentApplicationRepository(SqlConnection connection)
        {
            this.connection = connection;

        }
        public void Add(StudentApplication entity)
        {
            String query = "INSERT INTO StudentApplication " +
                "SET Grade = @Grade, " +
                    "Amount = @Amount, " +
                    "Comment = @Comment, " +
                    "StatusID = @StatusID, " +
                    "StudentID = @StudentID, " +
                    "Year = @Year, " +
                "WHERE ApplicationID = @Application ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Grade", entity.Grade);
            command.Parameters.AddWithValue("@Amount", entity.Amount);
            command.Parameters.AddWithValue("@Comment", entity.Comment);
            command.Parameters.AddWithValue("@StatusID", entity.StudentID);
            command.Parameters.AddWithValue("@Year", entity.Year);
            command.Parameters.AddWithValue("@ApplicationID", entity.ApplicationID);

            command.ExecuteNonQuery();

        }

        public IEnumerable<StudentApplication> GetAll()
        {
            string query = $"SELECT * FROM StudentApplication";

            foreach (DataRow row in GetDataTable(query).Rows)
            {
                int ApplicationID = int.Parse(row["ApplicationID"].ToString());
                int Grade = int.Parse(row["Grade"].ToString());
                decimal Amount = decimal.Parse(row["Amount"].ToString());
                string Comment = (row["Comment"].ToString());
                int StatusID = int.Parse(row["StatusID"].ToString());
                int StudentID = int.Parse(row["StudentID"].ToString());
                int Year = int.Parse(row["Year"].ToString());
                StudentApplication studentApplication = new StudentApplication(ApplicationID, Grade, Amount, Comment, StatusID, StudentID, Year);
                studentApplication.ApplicationID = int.Parse(row["ApplicationID"].ToString());
                yield return studentApplication;
            }
        }

        public StudentApplication GetById(int id)
        {
            StudentApplication entity;
            string query = $"SELECT * FROM StudentApplication WHERE ApplicationID = {id}";

            DataRow row = GetDataTable(query).Rows[0];
            int ApplicationID = int.Parse(row["ApplicationID"].ToString());
            int Grade = int.Parse(row["Grade"].ToString());
            int Amount = int.Parse(row["Amount"].ToString());
            string Comment = (row["Comment"].ToString());
            int StatusID = int.Parse(row["StatusID"].ToString());
            int StudentID = int.Parse(row["StudentID"].ToString());
            int Year = int.Parse(row["Year"].ToString());
            entity = new StudentApplication(ApplicationID, Grade, Amount, Comment, StatusID, StudentID, Year);

            return entity;
        }

        public void Update(StudentApplication newEntity)
        {
            string query = @"UPDATE StudentApplication " +
                    "SET Grade = @Grade, " + 
                        "Amount = @Amount, " +
                        "Comment = @Comment, " + 
                        "StatusID = @StatusID, " +
                        "StudentID = @StudentID, " +
                        "Year = @Year, " +
                    "WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            
            command.Parameters.AddWithValue("@Grade", newEntity.Grade);
            command.Parameters.AddWithValue("@Amount", newEntity.Amount);
            command.Parameters.AddWithValue("@Comment", newEntity.Comment);
            command.Parameters.AddWithValue("@StatusID", newEntity.StatusID);
            command.Parameters.AddWithValue("@StudentID", newEntity.StudentID);
            command.Parameters.AddWithValue("@Year", newEntity.Year);
            command.Parameters.AddWithValue("@ApplicationID", newEntity.ApplicationID);
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
