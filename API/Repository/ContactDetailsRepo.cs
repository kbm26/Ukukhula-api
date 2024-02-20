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
            string query = "INSERT INTO ContactDetails (Email, PhoneNumber) " +
                           "VALUES (@Email, @PhoneNumber)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", entity.Email);
                command.Parameters.AddWithValue("@PhoneNumber", entity.PhoneNumber);

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<ContactDetails> GetAll()
        {
            List<ContactDetails> contactDetailsList = new List<ContactDetails>();
            string query = "SELECT * FROM ContactDetails";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    foreach (DataRow row in GetDataTable(query).Rows)
                    {
                        int contactId = (int)row["ContactID"];
                        string email = row["email"].ToString();
                        int phoneNumber = (int)row["PhoneNumber"];

                        contactDetailsList.Add(new ContactDetails(contactId, email, phoneNumber));
                    }
                }
            }

            return contactDetailsList;
        }

        public ContactDetails GetById(int id)
        {
            string query = $"SELECT * FROM ContactDetails WHERE ContactID = @ContactID";

            DataRow row = GetDataTable(query).Rows[0];

            int contactId = (int)row["contactId"];
            string email = row["email"].ToString();
            int phoneNumber = (int)row["phoneNumber"];

            return new ContactDetails(contactId, email, phoneNumber);
        }

        public void Update(ContactDetails newEntity)
        {
            string query = "UPDATE ContactDetails SET " +
                           "Email = @Email, " +
                           "PhoneNumber = @PhoneNumber " +
                           "WHERE ContactID = @ContactID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", newEntity.Email);
                command.Parameters.AddWithValue("@PhoneNumber", newEntity.PhoneNumber);
                command.Parameters.AddWithValue("@ContactID", newEntity.ContactID);

                command.ExecuteNonQuery();
            }
        }


        private DataTable GetDataTable(string query)
        {
            DataTable dataTable = new DataTable();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }
    }
}
