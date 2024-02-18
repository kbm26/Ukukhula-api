﻿namespace API.Model
{
    public class UniversityFundApplication(int universityID, DateTime fundingYear, decimal amount, int statusID, string comment)
    {
        public int ApplicationID { get; set; }
        public int UniversityID { get; set; } = universityID;
        public DateTime FundingYear { get; set; } = fundingYear;
        public decimal Amount { get; set; } = amount;
        public int StatusID { get; set; } = statusID;
        public string Comment { get; set; } = comment;
    }
}
