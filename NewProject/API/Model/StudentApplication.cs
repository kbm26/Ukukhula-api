using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class StudentApplication(int Grade, int amount, char Comment, int Status,int StudentID, int Year)
    {
        [Key]
        public int ApplicationID;
        [Required]
        public int Grade { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public char Comment { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        public int StudentID { get; set; }
        [Required]
        public int Year { get; set; }

    }
}