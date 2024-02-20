using API.Model;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data.Common;

namespace API.Repository
{
    public class ContactDetailsRepository : IRepository<ContactDetails>
    {
        SqlConnection connection;

        public ContactDetailsRepository(SqlConnection connection)
        {
            this.connection = connection;
        }

        public void Add(ContactDetails entity)
        {
            string query = "INSERT INTO ContactDetails" +
                "SET Email = @Email, " +
                    "PhoneNumber = @PhoneNumner, " +
                "WHERE ContactID = @ContactID ";


            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", entity.Email);
                command.Parameters.AddWithValue("@PhoneNumber", entity.PhoneNumber);
                command.Parameters.AddWithValue("@ContactID", entity.ContactID);

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<ContactDetails> GetAll()
        {
            string query = $"SELECT * FROM ContactDetails";

            foreach (DataRow row in GetDataTable(query).Rows)
            {
                int ContactID = int.Parse(row["ContactID"].ToString()); 
                string Email = (row["Email"].ToString());
                int PhoneNumber = int.Parse(row["PhoneNumber"].ToString());    
                ContactDetails contactDetails = new ContactDetails(ContactID, Email, PhoneNumber);
                contactDetails.ContactID = int.Parse(row["ContactID"].ToString());
                yield return contactDetails;
            }
        }

        public ContactDetails GetById(int id)
        {
            string query = $"SELECT * FROM University WHERE ContactID = {id}";

            DataRow row = GetDataTable(query).Rows[0];
            int ContactID = int.Parse(row["ContactID"].ToString());
            string Email = (row["Email"].ToString());
            int PhoneNumber = int.Parse(row["PhoneNumber"].ToString());
            return new ContactDetails(ContactID, Email, PhoneNumber);
        }

        public void Update(ContactDetails newEntity)
        {
            string query = @"UPDATE ContactDetails "+
                    "SET Email = @Email, " +
                        "PhoneNumber = @PhoneNumber, " +
                    "WHERE ContactID = @ContactID";

            SqlCommand command = new SqlCommand(query, connection);

            
            command.Parameters.AddWithValue("@Email", newEntity.Email);
            command.Parameters.AddWithValue("@PhoneNumber", newEntity.PhoneNumber);
            command.Parameters.AddWithValue("@ContactID", newEntity.ContactID);
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
    
