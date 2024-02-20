using System.ComponentModel.DataAnnotations;

namespace API.Model
{


        public class ContactDetails(int contactId, string email, int phoneNumber)
        {
          
        

        [Key]
        public int ContactID { get; set; }= contactId;

        [Required]
        public string Email { get; set; } = email;

        [Required]
        public int PhoneNumber { get; set; } = phoneNumber;
}
}
