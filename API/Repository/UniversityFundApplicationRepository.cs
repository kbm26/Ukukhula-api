﻿using API.Model;
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
                UniversityFundApplication fund =    new UniversityFundApplication(UniversityID, fundDate, amount, StatusID, comment ?? "");
                fund.ApplicationID = int.Parse(row["ApplicationID"].ToString());
                yield return fund;

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
            string query = @"UPDATE UniversityStudentInformation 
                    SET UniversityID = @UniversityID,
                        FundingYear = @FundingYear, 
                        Amount = @Amount, 
                        StatusID = @StatusID, 
                        Comment = @Comment 
                    WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UniversityID", newEntity.UniversityID);
            command.Parameters.AddWithValue("@FundingYear", newEntity.FundingYear);
            command.Parameters.AddWithValue("@Amount", newEntity.Amount);
            command.Parameters.AddWithValue("@StatusID", newEntity.StatusID);
            command.Parameters.AddWithValue("@Comment", newEntity.Comment);
            command.Parameters.AddWithValue("@ApplicationID", newEntity.ApplicationID);
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
