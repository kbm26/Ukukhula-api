using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class BBDFund(decimal budget, DateTime FinancialYearStart, int universityID)
    {
        [Key]
        public int FundID { get; set; }  
        [Required]

        public decimal Budget { get; set; } = budget;
        [Required]

        public DateTime FinancialYearStart { get; set; } = FinancialYearStart;
        [Required]

        public int UniversityID { get; set; } = universityID;
    }
}
