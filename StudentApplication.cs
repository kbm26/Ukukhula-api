using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class StudentApplication
    {
        [Key]
        private int ApplicationID;
        [Required]
        private int Grade { get; set; }
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
