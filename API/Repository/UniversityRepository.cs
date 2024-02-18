using API.Model;
using System.Data.SqlClient;
using System.Data;

namespace API.Repository
{
    public class UniversityRepository(SqlConnection connection) : IRepository<University>
    {
        public void Add(University entity)
        {
            string query = "INSERT INTO University " +
                "([Name], [ProvinceID]) " +
                $"VALUES ({entity.Name}, {entity.ProvinceID} ) ";

            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
        }

        public IEnumerable<University> GetAll()
        {
            string query = $"SELECT * FROM University";

            foreach (DataRow row in GetDataTable(query).Rows)
            {
                
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
            string Name = row["Name"].ToString();
            int ProvinceID = int.Parse(row["ProvinceID"].ToString());
            return new University(Name,ProvinceID);
        }

        public void Update(University newEntity)
        {
            int UniversityID = newEntity.UniversityID;

            string query = $"UPDATE University SET Name = {newEntity.Name}, " +
                $"ProvinceID = {newEntity.ProvinceID} " +
                $"WHERE UniversityID = {UniversityID} ";

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
