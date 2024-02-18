using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class StudentInformation(int IDNumber, DateTime BirthDate, int Age, int Gender, int UserID, int RaceID)
    {
        [Key]
        public int StudentID;
        [Required]
        public int IDNumber { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int Gender { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int RaceID { get; set; }

    }
}