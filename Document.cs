using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class Document
    {
        [Key]
        private int DocumentID;
        [Required]
        public String Transcript { get; set; }
        [Required]
        public String IdentityDocument { get; set; }
        [Required]
        private int ApplicationID { get; set; }

    }
}
