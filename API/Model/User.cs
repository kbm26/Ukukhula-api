using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int ContactID { get; set; }

        [Required]
        public int RoleID { get; set; }

        public User()
        {

        }

        public User(string firstName, string lastName, int contactID, int roleID)
        {
            FirstName = firstName;
            LastName = lastName;
            ContactID = contactID;
            RoleID = roleID;
        }
    }
}
