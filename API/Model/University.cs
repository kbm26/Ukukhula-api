using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class University( string Name, int ProvinceID)
    {
        [Key]
        public int UniversityID { get; set; } 
        [Required]

        public string Name { get; set; } = Name;
        [Required]
        public int ProvinceID { get; set; } = ProvinceID;



    }
}


