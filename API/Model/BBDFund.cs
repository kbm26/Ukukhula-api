using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class BBDFund
    public class BBDFund(decimal budget, DateTime fundingDate, int universityID)
    {
        [Key]
        public int FundID;
        public int FundID { get; set; }

        [Required]
        public int Budget { get; set; }
        public decimal Budget { get; set; } = budget;
        [Required]
        public DateTime FundingDate { get; set; }
        public DateTime FundingDate { get; set; } = fundingDate;
        [Required]
        public int UniversityID { get; set; }

        public BBDFund( int budget, DateTime fundingDate, int universityID)
        {
            Budget = budget;
            FundingDate = fundingDate;
            UniversityID = universityID;
        }
        public int UniversityID { get; set; } = universityID;
    }
}
