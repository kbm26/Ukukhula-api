using API.Model;
using System.Data.SqlClient;
using System.Data;

namespace API.Repository
{
    public class UniversityFundApplicationRepository(SqlConnection connection) : IRepository<UniversityFundApplication>
    {
        public void Add(UniversityFundApplication entity)
        {
            string query = "INSERT INTO UniversityFundApplication " +
                            "([UniversityID],[FundingYear],[Amount],[StatusID],[Comment]) " +
                            $"VALUES ({entity.UniversityID},  '{entity.FundingYear.Date}', {entity.Amount}, {entity.StatusID}, '{entity.Comment}' ) ";

            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
        }

        public IEnumerable<UniversityFundApplication> GetAll()
        {
            string query = $"SELECT * FROM UniversityFundApplication";

            foreach (DataRow row in GetDataTable(query).Rows)
            {
                int UniversityID = int.Parse(row["UniversityID"].ToString());
                DateTime fundDate = DateTime.Parse(row["FundingYear"].ToString());
                decimal amount = decimal.Parse(row["Amount"].ToString());
                int StatusID = int.Parse(row["StatusID"].ToString());
                string comment = row["Comment"].ToString();
                yield return new UniversityFundApplication(UniversityID, fundDate, amount, StatusID, comment ?? "");

            }
        }

        public UniversityFundApplication GetById(int id)
        {
            string query = $"SELECT * FROM UniversityFundApplication WHERE ApplicationID = {id}";

            DataRow row = GetDataTable(query).Rows[0];
            int UniversityID = int.Parse(row["UniversityID"].ToString());
            DateTime fundDate = DateTime.Parse(row["FundingYear"].ToString());
            decimal amount = decimal.Parse(row["Amount"].ToString());
            int StatusID = int.Parse(row["StatusID"].ToString());
            string comment = row["Comment"].ToString();
            return new UniversityFundApplication(UniversityID,fundDate,amount,StatusID, comment ?? "");



        }

        public void Update(UniversityFundApplication newEntity)
        {
            int applicationID = newEntity.ApplicationID;

            string query = $"UPDATE UniversityStudentInformation SET UniversityID = {newEntity.UniversityID} " +
                $"FundingYear = {newEntity.FundingYear}, " +
                $"Amount = {newEntity.Amount}, " +
                $"StatusID = {newEntity.StatusID}, " +
                $"Comment = {newEntity.Comment} " +
                $"WHERE ApplicationID = {applicationID} ";

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
