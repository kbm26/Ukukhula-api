using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class HOD(int UserID, int UniversityID)
    {


        [Key]
        public int UserID { get; set; } = UserID;

        [Required]
        public int UniversityID { get; set; } = UniversityID;
    }
}

