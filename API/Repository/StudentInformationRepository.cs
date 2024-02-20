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
                "([IDNumber], [Birhtdate], [Age], [Gender], [UserID], [RaceID])" +
                $"VALUES ({entity.IDNumber}, '{entity.BirthDate}', {entity.Age}, {entity.Gender} {entity.UserID}, {entity.RaceID})";

            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();

        }

        public IEnumerable<StudentInformation> GetAll()
        {
            string query = $"SELECT * FROM StudentInformation";

            foreach (DataRow row in GetDataTable(query).Rows)
            {
                string IDNumber = row["IDNumber"].ToString();
                DateTime BirhtDate = DateTime.Parse(row["BirthDate"].ToString());
                int Age = int.Parse(row["Age"].ToString());
                string Gender = row["Gender"].ToString();
                int UserID = int.Parse(row["UserID"].ToString());
                int RaceID = int.Parse(row["RaceID"].ToString());
                yield return new StudentInformation(IDNumber, BirhtDate, Age, Gender, UserID, RaceID);
            }
        }

        public StudentInformation GetById(int id)
        {
            StudentInformation entity;
            string query = $"SELECT * FROM StudentInformation WHERE StudnentID = {id}";

            DataRow row = GetDataTable(query).Rows[0];
            string IDNumber = row["IDNumber"].ToString();
            DateTime BirhtDate = DateTime.Parse(row["BirthhDate"].ToString());
            int Age = int.Parse(row["Age"].ToString());
            string Gender = row["Gender"].ToString();
            int UserID = int.Parse(row["UserID"].ToString());
            int RaceID = int.Parse(row["RaceID"].ToString());
            entity = new StudentInformation(IDNumber, BirhtDate, Age, Gender, UserID, RaceID);


            return entity;

        }

        public void Update(StudentInformation newEntity)
        {
            int entityID = newEntity.StudentID;

            StudentInformation oldEntity = GetById(entityID);
            String query = $"UPDATE StudentInformation SET IDNumber = {newEntity.IDNumber} " +
                $"BirthDate = {newEntity.BirthDate}" +
                $"Age = {newEntity.Age} " +
                $"Gender = {newEntity.Gender} " +
                $"UserID = {newEntity.UserID} " +
                $"RaceID = {newEntity.RaceID}" +
                $"WHERE StudentID = {entityID} ";

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

        