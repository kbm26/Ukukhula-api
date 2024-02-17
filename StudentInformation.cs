using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class StudentInformation
    {
        [Key]
        private int StudentID;
        [Required]
        private int IDNumber { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int RaceID { get; set; }

    }
}
