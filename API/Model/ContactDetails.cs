using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class ContactDetails(string Email, string PhoneNumber)
    {
        [Key]
        public int ContactID { get; set; } 
        [Required]
        public string Email { get; set; } = Email;
        [Required]
        public String PhoneNumber { get; set; } = PhoneNumber;
    }
}
