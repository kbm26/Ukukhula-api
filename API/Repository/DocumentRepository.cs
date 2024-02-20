using API.Model;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Security.Cryptography;
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
               "VALUES (CONVERT(varbinary(max), @Transcript), CONVERT(varbinary(max), @IdentityDocument), @ApplicationID)";



            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Transcript", entity.Transcript);
            command.Parameters.AddWithValue("@IdentityDocument", entity.IdentityDocument);
            command.Parameters.AddWithValue("@ApplicationID", entity.ApplicationID);

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
                Document document = new Document(Transcript, IdenetityDocument, ApplicationID);
                document.DocumentID = int.Parse(row["DocumentID"].ToString());
                yield return document;

            }
        }

        public Document GetById(int id)
        {
            string query = $"SELECT * FROM Document WHERE DocumentID = {id}";

            DataRow row = GetDataTable(query).Rows[0];
            String Transcript = (row["Transcript"].ToString());
            String IdenetityDocument = (row)["IdentityDocument"].ToString();
            int ApplicationID = Convert.ToInt32(row["ApplicationID"]); ;
            Document entity = new Document(Transcript, IdenetityDocument, ApplicationID);
            entity.DocumentID = id;
            return entity;

        }

        public void Update(Document newEntity)
        {
            string query = @"UPDATE Document" + 
                    "SET Transcript = @Transcript, " + 
                        "IdentityDocument = @IdentityDocument, " +
                        "ApplicationID = @ApplicationID, "+
                    "WHERE DocumentID = @DocumentID";

            SqlCommand command = new SqlCommand(query, connection);

            
            command.Parameters.AddWithValue("@Transcript", newEntity.Transcript);
            command.Parameters.AddWithValue("@IdentityDocument", newEntity.IdentityDocument);
            command.Parameters.AddWithValue("@ApplicationID", newEntity.ApplicationID);
            command.Parameters.AddWithValue("@DocumentID", newEntity.DocumentID);
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
    