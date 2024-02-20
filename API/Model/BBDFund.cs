using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class BBDFund(decimal budget, DateTime fundingDate, int universityID)
    {
<<<<<<< Updated upstream

        public int FundID { get; set; }

        public decimal Budget { get; set; } = budget;

        public DateTime FundingDate { get; set; } = fundingDate;

        [Key]
        public int FundID { get; set; }

        [Required]
        public decimal Budget { get; set; } = budget;
        [Required]
        public DateTime FundingDate { get; set; } = fundingDate;
        [Required]
        public int UniversityID { get; set; } = universityID;
    }
}
