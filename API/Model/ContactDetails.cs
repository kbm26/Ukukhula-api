using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class ContactDetails(int ContactID, string Email, int PhoneNumber)
    {
        [Key]
        public int ContactID { get; set; } = ContactID;
        [Required]
        public string Email { get; set; } = Email;
        [Required]
        public int PhoneNumber { get; set; } = PhoneNumber;
    }
}
