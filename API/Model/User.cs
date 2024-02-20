using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class User(string firstName, string lastName, int contactID, int roleID)
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        public string FirstName { get; set; } = firstName;

        [Required]
        public string LastName { get; set; } = lastName;

        [Required]
        public int ContactID { get; set; } = contactID;

        [Required]
        public int RoleID { get; set; } = roleID;


    }
}
