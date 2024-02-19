using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class HOD(int userId, int universityId)
    {        

        [Key]
        public int UserID { get; set; } = userId;

        [Required]
        public int UniversityID { get; set; } = universityId;
    }
}

