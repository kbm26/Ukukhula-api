using API.Model;
using System.Data;
using System.Data.SqlClient;

namespace API.Repository
{
    public class UniversityStudentInformationRepository(SqlConnection connection) : IRepository<UniversityStudentInformation>
    {
        public void Add(UniversityStudentInformation entity)
        {
            string query = "INSERT INTO UniversityStudentInformation " +
            "([UniversityID],[StudentID]) " +
            $"VALUES ({entity.UniversityID},  {entity.StudentID}) ";

            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
        }

        public IEnumerable<UniversityStudentInformation> GetAll()
        {
            string query = $"SELECT * FROM UniversityStudentInformation";

            foreach (DataRow row in GetDataTable(query).Rows)
            {
                int UniversityID = int.Parse(row["UniversityID"].ToString());
                int StudentID = int.Parse(row["StudentID"].ToString());
                yield return new UniversityStudentInformation(StudentID,UniversityID);
            }
        }

        public UniversityStudentInformation GetById(int id)
        {
            string query = $"SELECT * FROM UniversityStudentInformation WHERE StudentID = {id}";

            DataRow row = GetDataTable(query).Rows[0];
            int UniversityID = int.Parse(row["UniversityID"].ToString());
            int StudentID = int.Parse(row["StudentID"].ToString());
            return new UniversityStudentInformation(StudentID, UniversityID);
        }

        public void Update(UniversityStudentInformation newEntity)
        {
            int StudentID = newEntity.StudentID;

            string query = $"UPDATE UniversityStudentInformation SET UniversityID = {newEntity.UniversityID} " +
                $"WHERE StudentID = {StudentID} ";

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
