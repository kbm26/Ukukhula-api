using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class ContactDetails
    {

        public ContactDetails(int contactId, string email, int phoneNumber)
        {
            ContactID = contactId;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        [Key]
        public int ContactID { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int PhoneNumber { get; set; }
    }
}
