using System.ComponentModel.DataAnnotations;

namespace API.Service.DTOs
{
    public class StudentDTO
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string IDNumber { get; set; }
        [RegularExpression(@"^\d{4}-\d{2}-\d{2}$", ErrorMessage = "Date must be in yyyy-MM-dd format")]
        public string birthDate { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string gender { get; set; }
        public string race { get; set; }
        public int universityID { get; set; }

    }

    
}
