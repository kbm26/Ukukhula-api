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
                "SET Transcript = @Transcript, " +
                    "IdentityDocument = @IdentityDocument, " +
                    "ApplicationID = @ApplicationID, " +
                "WHERE DocumentID = @DocumentID";
            

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Transcript", entity.Transcript);
            command.Parameters.AddWithValue("@IdentityDocment", entity.IdentityDocument);
            command.Parameters.AddWithValue("@ApplicationID", entity.ApplicationID);
            command.Parameters.AddWithValue("@DocumentID", entity.DocumentID);


            command.ExecuteNonQuery();

        }

        public IEnumerable<Document> GetAll()
        {
            string query = $"SELECT * FROM Document";

            foreach(DataRow row in GetDataTable(query).Rows)
            {
                int DocumentID = int.Parse(row["DocumentID"].ToString());
                String Transcript = (row["Transcript"].ToString());
                String IdenetityDocument = (row)["IdentityDocument"].ToString();
                int ApplicationID = Convert.ToInt32(row["ApplicationID"]); ;
                Document document = new Document(DocumentID, Transcript, IdenetityDocument, ApplicationID);
                document.DocumentID = int.Parse(row["DocumentID"].ToString());
                yield return document;

            }
        }

        public Document GetById(int id)
        {
            Document entity;
            string query = $"SELECT * FROM Document WHERE DocumentID = {id}";

            DataRow row = GetDataTable(query).Rows[0];
            int DocumentID = int.Parse(row["DocumentID"].ToString());
            String Transcript = (row["Transcript"].ToString());
            String IdenetityDocument = (row)["IdentityDocument"].ToString();
            int ApplicationID = Convert.ToInt32(row["ApplicationID"]); ;
            return new Document(DocumentID, Transcript, IdenetityDocument, ApplicationID);

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
    