using API.Model;
using System.Data.SqlClient;

namespace API.Repository
{
    public class BBDFundRepository : IRepository<BBDFund>
    {
        SqlConnection connection;
        public BBDFundRepository(SqlConnection connection) {
            this.connection = connection;
           
        }
        public void Add(BBDFund entity)
        {
            String query = "INSERT INTO BBDFund "+
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
        }

        public BBDFund GetById(int id)
        {   //SELECT * FROM BBDFUND WHERE FundID = {id}
            //turn that data into bbdfund model object
            throw new NotImplementedException();
        }

        public void Update(BBDFund newEntity)
        {
            int entityID = newEntity.FundID;

            BBDFund oldEntity =  GetById(entityID);
            String query = $"UPDATE BBDFund SET Budget = {newEntity.Budget} " +
                $"Financialyearstart = {newEntity.FundingDate}" +
                $"UniversityID = {newEntity.UniversityID} " +
                $"WHERE FundID = {entityID} ";

            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
        }
    }
}
