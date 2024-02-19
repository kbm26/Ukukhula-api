using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class StudentInformation(int IDNumber, DateTime BirthDate, int Age, int Gender, int UserID, int RaceID)
    {
        [Key]
        public int StudentID;
        [Required]
        public int IDNumber { get; set; } = IDNumber;
        [Required]
        public DateTime BirthDate { get; set; } = BirthDate;
        [Required]
        public int Age { get; set; } = Age;
        [Required]
        public int Gender { get; set; } = Gender;
        [Required]
        public int UserID { get; set; } = UserID;
        [Required]
        public int RaceID { get; set; } = RaceID;

    }
}