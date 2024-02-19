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
                "([Grade], [Amount], [Comment], [Status], [StudentID] [Year]) " +
                $"VALUES ({entity.Grade}, '{entity.Amount}', {entity.Comment}, {entity.Status} {entity.StudentID}, {entity.Year}) ";

            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();

        }

        public IEnumerable<StudentApplication> GetAll()
        {
            string query = $"SELECT * FROM StudentApplication";

            foreach (DataRow row in GetDataTable(query).Rows)
            {
                int Grade = int.Parse(row["Grade"].ToString());
                decimal Amount = decimal.Parse(row["Amount"].ToString()) ;
                string Comment = (row["Comment"].ToString());
                int Status = int.Parse(row["StatusID"].ToString());
                int StudentID = int.Parse(row["StudentID"].ToString());
                int Year = int.Parse(row["Year"].ToString());
                yield return new StudentApplication(Grade, Amount, Comment, Status, StudentID, Year);
            }
        }

        public StudentApplication GetById(int id)
        {
            StudentApplication entity;
            string query = $"SELECT * FROM StudentApplication WHERE ApplicationID = {id}";

            DataRow row = GetDataTable(query).Rows[0];
            int Grade = int.Parse(row["Grade"].ToString());
            decimal Amount = decimal.Parse(row["Amount"].ToString());
            string Comment = (row["Comment"].ToString());
            int Status = int.Parse(row["StatusID"].ToString());
            int StudentID = int.Parse(row["StudentID"].ToString());
            int Year = int.Parse(row["Year"].ToString());
            entity = new StudentApplication(Grade, Amount, Comment, Status, StudentID, Year);
            entity.ApplicationID = id;

            return entity;
        }

        public void Update(StudentApplication newEntity)
        {
            string query = @"UPDATE StudentApplication 
                    SET Grade = @Grade, 
                        Amount = @Amount, 
                        Comment = @Comment, 
                        StatusID = @Status, 
                        StudentID = @StudentID, 
                        Year = @Year 
                    WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            // Add parameters to the command
            command.Parameters.AddWithValue("@Grade", newEntity.Grade);
            command.Parameters.AddWithValue("@Amount", newEntity.Amount);
            command.Parameters.AddWithValue("@Comment", newEntity.Comment);
            command.Parameters.AddWithValue("@Status", newEntity.Status);
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
