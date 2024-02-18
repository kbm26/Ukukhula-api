using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class HOD
    {
        public HOD()
        {

        }

        public HOD(int userId, int universityId)
        {
            UserID = userId;
            UniversityID = universityId;
        }

        [Key]
        public int UserID { get; set; }

        [Required]
        public int UniversityID { get; set; }
    }
}

