using API.Model;
using System.Data;
using System.Data.SqlClient;

namespace API.Repository
{
    public class BBDFundRepository(SqlConnection connection) : IRepository<BBDFund>
    {
        

        public void Add(BBDFund entity)
        {
            string query = "INSERT INTO BBDFund "+
                "([Budget], [FinancialYearStart], [UniversityID]) "+
                $"VALUES ({entity.Budget}, '{entity.FundingDate.Date}', {entity.UniversityID}) ";

            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            
        }

        public IEnumerable<BBDFund> GetAll()
        {
            string query = $"SELECT * FROM BBDFUND";

            foreach(DataRow row in  GetDataTable(query).Rows)
            {
                decimal budget = decimal.Parse(row["Budget"].ToString());
                DateTime fundDate = DateTime.Parse(row["Financialyearstart"].ToString());
                int UniversityID = int.Parse(row["UniversityID"].ToString());
                yield return  new BBDFund(budget, fundDate, UniversityID);
            }

        }

        public BBDFund GetById(int id)
        {
            BBDFund entity;
            string query = $"SELECT * FROM BBDFUND WHERE FundID = {id}";

            DataRow row = GetDataTable(query).Rows[0];
            decimal budget = decimal.Parse(row["Budget"].ToString());
            DateTime fundDate = DateTime.Parse(row["Financialyearstart"].ToString());
            int UniversityID = int.Parse(row["UniversityID"].ToString());
            entity = new BBDFund(budget,fundDate, UniversityID);


            return entity;


        }

        public void Update(BBDFund newEntity)
        {
            int entityID = newEntity.FundID;

            string query = $"UPDATE BBDFund SET Budget = {newEntity.Budget}, " +
                $"Financialyearstart = {newEntity.FundingDate}, " +
                $"UniversityID = {newEntity.UniversityID} " +
                $"WHERE FundID = {entityID} ";

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
