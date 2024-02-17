using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class BBDFund
    {
        [Key]
        private int FundID;
        [Required]
        public int Budget { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        private int UniversityID { get; set; }

    }
}
