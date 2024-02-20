using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class University(int UniversityID, string Name, int ProvinceID)
    {
        [Key]
        public int UniversityID { get; set; } = UniversityID;
        [Required]

        public string Name { get; set; } = Name;
        [Required]
        public int ProvinceID { get; set; } = ProvinceID;



    }
}


