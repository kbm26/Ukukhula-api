using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class UniversityStudentInformation(int StudentID, int UniversityID)
    {
        [Required]
        public int StudentID { get; set; } = StudentID;
        [Required]
        public int UniversityID { get; set; } = UniversityID;
    }   
}
