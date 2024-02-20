using API.Model;
using System.Data;
using System.Data.SqlClient;

namespace API.Repository
{
    public class BBDFundRepository(SqlConnection connection) : IRepository<BBDFund>
    {

        

        public void Add(BBDFund entity)
        {
            string query = @"UPDATE BBDFund
                     SET Budget = @Budget,
                         FinancialYearStart = @FinancialYearStart,
                         UniversityID = @UniversityID
                     WHERE FundID = @FundID";



            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Budget", entity.Budget);
            command.Parameters.AddWithValue(" @FinancialYearStart", entity.FinancialYearStart);
            command.Parameters.AddWithValue("@UniversityID", entity.UniversityID);
            command.Parameters.AddWithValue("@FundID", entity.FundID);

           
            command.ExecuteNonQuery();
            
        }

        public IEnumerable<BBDFund> GetAll()
        {
            
            string query = $"SELECT * FROM BBDFUND";

            foreach(DataRow row in  GetDataTable(query).Rows)
            {
                int FundID = int.Parse(row["FundID"].ToString());
                decimal budget = decimal.Parse(row["Budget"].ToString());
                DateTime FinancialYearStart = DateTime.Parse(row["Financialyearstart"].ToString());
                int UniversityID = int.Parse(row["UniversityID"].ToString());
                BBDFund bBDFund = new BBDFund(budget, FinancialYearStart, UniversityID);
                bBDFund.FundID = int.Parse(row["FundID"].ToString()) ;
                yield return bBDFund;
            }

        }

        public BBDFund GetById(int id)
        {   
        
            BBDFund entity;
            string query = $"SELECT * FROM BBDFUND WHERE FundID = {id}";

            DataRow row = GetDataTable(query).Rows[0];
            int FundID = int.Parse(row["FundID"].ToString());
            decimal budget = decimal.Parse(row["Budget"].ToString());
            DateTime FinancialYearStart = DateTime.Parse(row["Financialyearstart"].ToString());
            int UniversityID = int.Parse(row["UniversityID"].ToString());
            entity = new BBDFund(budget,FinancialYearStart, UniversityID);


            return entity;


        }

        public void Update(BBDFund newEntity)
        {
            string query = @"UPDATE BBDFund
                     SET Budget = @Budget,
                         FinancialYearStart = @FinancialYearStart,
                         UniversityID = @UniversityID
                     WHERE FundID = @FundID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Budget", newEntity.Budget);
            command.Parameters.AddWithValue("@FinancialYearStart", newEntity.FinancialYearStart);
            command.Parameters.AddWithValue("@UniversityID", newEntity.UniversityID);
            command.Parameters.AddWithValue("@FundID", newEntity.FundID); // Adding FundID parameter

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
