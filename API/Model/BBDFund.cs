using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class BBDFund(decimal budget, DateTime fundingDate, int universityID)
    {

        public int FundID { get; set; }

        public decimal Budget { get; set; } = budget;

        public DateTime FundingDate { get; set; } = fundingDate;

        public int UniversityID { get; set; } = universityID;
    }
}
