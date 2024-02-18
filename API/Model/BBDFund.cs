using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class BBDFund
    {
        [Key]
        public int FundID;

        [Required]
        public int Budget { get; set; }
        [Required]
        public DateTime FundingDate { get; set; }
        [Required]
        public int UniversityID { get; set; }

        public BBDFund( int budget, DateTime fundingDate, int universityID)
        {
            Budget = budget;
            FundingDate = fundingDate;
            UniversityID = universityID;
        }
    }
}
