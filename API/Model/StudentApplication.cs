using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class StudentApplication(int Grade, decimal amount, string Comment, int Status,int StudentID, int Year)
    {
        [Key]
        public int ApplicationID;
        [Required]
        public int Grade { get; set; } = Grade;
        [Required]
        public decimal Amount { get; set; } = amount;
        [Required]
        public string Comment { get; set; } = Comment;
        [Required]
        public int Status { get; set; } = Status;
        [Required]
        public int StudentID { get; set; } = StudentID;
        [Required]
        public int Year { get; set; } = Year;

    }
}