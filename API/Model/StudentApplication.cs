using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class StudentApplication(int ApplicationID, int Grade, decimal Amount, string Comment, int StatusID,int StudentID, int Year)
    {
        [Key]
        public int ApplicationID { get; set; } = ApplicationID;
        [Required]
        public int Grade { get; set; } = Grade;
        [Required]
        public decimal Amount { get; set; } = Amount;
        [Required]
        public string Comment { get; set; } = Comment;
        [Required]
        public int StatusID { get; set; } = StatusID;
        [Required]
        public int StudentID { get; set; } = StudentID;
        [Required]
        public int Year { get; set; } = Year;

    }
}