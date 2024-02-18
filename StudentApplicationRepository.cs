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
                int Amount = int.Parse(row["Amount"].ToString()) ;
                char Comment = char.Parse(row["Comment"].ToString());
                int Status = int.Parse(row["Staus"].ToString());
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
            int Amount = int.Parse(row["Amount"].ToString());
            char Comment = char.Parse(row["Comment"].ToString());
            int Status = int.Parse(row["Staus"].ToString());
            int StudentID = int.Parse(row["StudentID"].ToString());
            int Year = int.Parse(row["Year"].ToString());
            entity = new StudentApplication(Grade, Amount, Comment, Status, StudentID, Year);

            return entity;
        }

        public void Update(StudentApplication newEntity)
        {
            int entityID = newEntity.ApplicationID;

            StudentApplication oldEntity = GetById(entityID);
            String query = $"UPDATE StudentApplication SET Grade = {newEntity.Grade} " +
                $"Amount = {newEntity.Amount}" +
                $"Comment = {newEntity.Comment} " +
                $"Status = {newEntity.Status} " +
                $"StudentID = {newEntity.StudentID} " +
                $"Year = {newEntity.Year}" +
                $"WHERE ApplicationID = {entityID} ";

            SqlCommand command = new SqlCommand(query, connection);
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
