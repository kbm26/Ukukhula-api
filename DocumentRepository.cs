using API.Model;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using Document = API.Model.Document;

namespace API.Repository
{
    public class DocumentRepository : IRepository<Document>
    {
        SqlConnection connection;
        public DocumentRepository(SqlConnection connection)
        {
            this.connection = connection;

        }
        public void Add(Document entity)
        {
            String query = "INSERT INTO Document " +
                "([Transcript], [IdentityDocument], [ApplicationID]) " +
                $"VALUES ({entity.Transcript}, '{entity.IdentityDocument}', {entity.ApplicationID}) ";

            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();

        }

        public IEnumerable<Document> GetAll()
        {
            string query = $"SELECT * FROM Document";

            foreach(DataRow row in GetDataTable(query).Rows)
            {
                String Transcript = (row["Transcript"].ToString());
                String IdenetityDocument = (row)["IdentityDocument"].ToString();
                int ApplicationID = Convert.ToInt32(row["ApplicationID"]); ;
                yield return new Document(Transcript, IdenetityDocument, ApplicationID);

            }
        }

        public Document GetById(int id)
        {
            Document entity;
            string query = $"SELECT * FROM Document WHERE DocumentID = {id}";

            DataRow row = GetDataTable(query).Rows[0];
            String Transcript = (row["Transcript"].ToString());
            String IdenetityDocument = (row)["IdentityDocument"].ToString();
            int ApplicationID = Convert.ToInt32(row["ApplicationID"]); ;
            entity = new Document(Transcript, IdenetityDocument, ApplicationID);

            return entity;

        }

        public void Update(Document newEntity)
        {
            int entityID = newEntity.DocumentID;

            Document oldEntity = GetById(entityID);
            String query = $"UPDATE Document SET Transcript = {newEntity.Transcript} " +
                $"IdentityDocument = {newEntity.IdentityDocument}" +
                $"ApplicationID = {newEntity.ApplicationID} " +
                $"WHERE DocumentID = {entityID} ";

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
    