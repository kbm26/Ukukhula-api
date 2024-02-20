using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class StudentInformation(string IDNumber, DateTime BirthDate, int Age, string Gender, int UserID, int RaceID)
    {
        [Key]
        public int StudentID;
        [Required]
        public string IDNumber { get; set; } = IDNumber;
        [Required]
        public DateTime BirthDate { get; set; } = BirthDate;
        [Required]
        public int Age { get; set; } = Age;
        [Required]
        public string Gender { get; set; } = Gender;
        [Required]
        public int UserID { get; set; } = UserID;
        [Required]
        public int RaceID { get; set; } = RaceID;

    }
}