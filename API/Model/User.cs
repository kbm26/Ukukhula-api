using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class User(int UserID, string FirstName, string LastName, int ContactID, int RoleID)
    {
        [Key]
        public int UserID { get; set; } = UserID;

        [Required]
        public string FirstName { get; set; } = FirstName;

        [Required]
        public string LastName { get; set; } = LastName;

        [Required]
        public int ContactID { get; set; } = ContactID;

        [Required]
        public int RoleID { get; set; } = RoleID;
    }
}
     
