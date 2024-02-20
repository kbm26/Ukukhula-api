using System.ComponentModel.DataAnnotations;

namespace API.Model
{

    public class UniversityFundApplication(int ApplicationID, int universityID, DateTime fundingYear, decimal amount, int statusID, string comment)
    {

        [Key]
        public int ApplicationID { get; set; } = ApplicationID;
        [Required]
        public int UniversityID { get; set; } = universityID;
        [Required]
        public DateTime FundingYear { get; set; } = fundingYear;
        [Required]
        public decimal Amount { get; set; } = amount;
        [Required]
        public int StatusID { get; set; } = statusID;
        [Required]
        public string Comment { get; set; } = comment;
    }
}
