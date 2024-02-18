using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class Document(string Transcript, string IdentityDocument, int ApplicationID)
    {
        [Key]
        public int DocumentID;
        [Required]
        public String Transcript { get; set; }
        [Required]
        public String IdentityDocument { get; set; }
        [Required]
        public int ApplicationID { get; set; }

    }
}