using API.Model;
using System.Data.SqlClient;
using System.Data;

namespace API.Repository
{
    public class UniversityRepository(SqlConnection connection) : IRepository<University>
    {
        public void Add(University entity)
        {
            string query = "INSERT INTO University (Name, ProvinceID) VALUES (@Name, @ProvinceID) ";
                

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", entity.Name);
            command.Parameters.AddWithValue("@ProvinceID", entity.ProvinceID);
            command.ExecuteNonQuery();
        }

        public IEnumerable<University> GetAll()
        {
            string query = $"SELECT * FROM University";

            foreach (DataRow row in GetDataTable(query).Rows)
            {
                int UniversityID = int.Parse(row["UniversityID"].ToString());
                string Name = row["Name"].ToString();
                int ProvinceID = int.Parse(row["ProvinceID"].ToString());
                University university = new University(Name, ProvinceID);
                university.UniversityID = int.Parse(row["UniversityID"].ToString());
                yield return university;
            }
        }

        public University GetById(int id)
        {
            string query = $"SELECT * FROM University WHERE UniversityID = {id}";

            DataRow row = GetDataTable(query).Rows[0];
            int UniversityID = int.Parse(row["UniversityID"].ToString());  
            string Name = row["Name"].ToString();
            int ProvinceID = int.Parse(row["ProvinceID"].ToString());
            University uni = new University(Name, ProvinceID);
            uni.UniversityID = int.Parse(row["UniversityID"].ToString());

            return uni;
        }

        public void Update(University newEntity)
        {
            string query = @"UPDATE University SET Name = @Name, ProvinceID = @ProvinceID WHERE UniversityID = @UniversityID";

            SqlCommand command = new SqlCommand(query, connection);

            
            command.Parameters.AddWithValue("@Name", newEntity.Name);
            command.Parameters.AddWithValue("@ProvinceID", newEntity.ProvinceID);
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
