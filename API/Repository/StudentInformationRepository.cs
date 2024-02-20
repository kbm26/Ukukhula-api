using API.Model;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;

namespace API.Repository
{
    public class StudentInformationRepository : IRepository<StudentInformation>
    {
        SqlConnection connection;
        public StudentInformationRepository(SqlConnection connection)
        {
            this.connection = connection;

        }
        public void Add(StudentInformation entity)
        {
            String query = "INSERT INTO StudentInformation" +
                "SET IDNumber = @IDNumber," +
                    "BirthDate = @BirthDate," +
                    "Age = @Age," +
                    "Gender = @Gender," +
                    "UserID = @UserID," +
                    "RaceID = @RaceID," +
                "WHERE StudentID = @StudentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@IDNumber", entity.IDNumber);
            command.Parameters.AddWithValue("@BirthDate", entity.BirthDate);
            command.Parameters.AddWithValue("@Age", entity.Age);
            command.Parameters.AddWithValue("@Gender", entity.Gender);
            command.Parameters.AddWithValue("@UserID", entity.UserID);
            command.Parameters.AddWithValue("@RaceID", entity.RaceID);
            command.Parameters.AddWithValue("@StudentID", entity.StudentID);

            command.ExecuteNonQuery();

        }

        public IEnumerable<StudentInformation> GetAll()
        {
            string query = $"SELECT * FROM StudentInformation";

            foreach (DataRow row in GetDataTable(query).Rows)
            {
                int StudentID = int.Parse(row["StudentID"].ToString());
                string IDNumber = (row["IDNumber"].ToString());
                DateTime BirthDate = DateTime.Parse(row["BirthDate"].ToString());
                int Age = int.Parse(row["Age"].ToString());
                string Gender = (row["Gender"].ToString());
                int UserID = int.Parse(row["UserID"].ToString());
                int RaceID = int.Parse(row["RaceID"].ToString());
                StudentInformation studentinformation = new StudentInformation(StudentID, IDNumber, BirthDate, Age, Gender, UserID, RaceID);
                studentinformation.StudentID = int.Parse(row["StudentID"].ToString());
                yield return studentinformation;
            }
        }

        public StudentInformation GetById(int id)
        {
            StudentInformation entity;
            string query = $"SELECT * FROM StudentInformation WHERE StudentID = {id}";

            DataRow row = GetDataTable(query).Rows[0];
            int StudentID = int.Parse(row["StudentID"].ToString());
            string IDNumber =(row["IDNumber"].ToString());
            DateTime BirhtDate = DateTime.Parse(row["BirthhDate"].ToString());
            int Age = int.Parse(row["Age"].ToString());
            string Gender = (row["Gender"].ToString());
            int UserID = int.Parse(row["UserID"].ToString());
            int RaceID = int.Parse(row["RaceID"].ToString());
            entity = new StudentInformation(StudentID, IDNumber, BirhtDate, Age, Gender, UserID, RaceID);


            return entity;

        }

        public void Update(StudentInformation newEntity)
        {
            string query = @"UPDATE StudentInformation " + 
                    "SET IDNumber = @IDNumber, " + 
                        "BirthDate = @BirthDate, " + 
                        "Age = @Age, " +
                        "Gender = @Gender, " +
                        "UserID = @UserID, " + 
                        "RaceID = @RaceID, " +
                    "WHERE StudentID = @StudentID";

            SqlCommand command = new SqlCommand(query, connection);

            
            command.Parameters.AddWithValue("@IdNumber", newEntity.IDNumber);
            command.Parameters.AddWithValue("@Birthdate", newEntity.BirthDate);
            command.Parameters.AddWithValue("@Age", newEntity.Age);
            command.Parameters.AddWithValue("@Gender", newEntity.Gender);
            command.Parameters.AddWithValue("@UserID", newEntity.UserID);
            command.Parameters.AddWithValue("@RaceID", newEntity.RaceID);
            command.Parameters.AddWithValue("@Student", newEntity.StudentID);
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

        