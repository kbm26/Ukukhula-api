using API.Model;
using System.Data;
using System.Data.SqlClient;

namespace API.Repository
{
    public class BBDFundRepository : IRepository<BBDFund>
    public class BBDFundRepository(SqlConnection connection) : IRepository<BBDFund>
    {
        SqlConnection connection;
        public BBDFundRepository(SqlConnection connection) {
            this.connection = connection;
           
        }
        

        public void Add(BBDFund entity)
        {
            String query = "INSERT INTO BBDFund "+
            string query = "INSERT INTO BBDFund "+
                "([Budget], [FinancialYearStart], [UniversityID]) "+
                $"VALUES ({entity.Budget}, '{entity.FundingDate.Date}', {entity.UniversityID}) ";

            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            
        }

        public IEnumerable<BBDFund> GetAll()
        {
            //SELECT * FROM BBDFUND
            //turn that data into bbdfund model objects
            throw new NotImplementedException();
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
        {   //SELECT * FROM BBDFUND WHERE FundID = {id}
            //turn that data into bbdfund model object
            throw new NotImplementedException();
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

            BBDFund oldEntity =  GetById(entityID);
            String query = $"UPDATE BBDFund SET Budget = {newEntity.Budget} " +
                $"Financialyearstart = {newEntity.FundingDate}" +
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
