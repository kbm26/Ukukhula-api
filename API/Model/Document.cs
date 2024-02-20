using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class Document(int DocumentID, string Transcript, string IdentityDocument, int ApplicationID)
    {
        [Key]
        public int DocumentID { get; set; } = DocumentID;
        [Required]
        public String Transcript { get; set; } = Transcript;
        [Required]

        public String IdentityDocument { get; set; } = IdentityDocument;
        [Required]
        public int ApplicationID { get; set; } = ApplicationID;

    }
}