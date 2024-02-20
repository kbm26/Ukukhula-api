namespace API.Service.DTOs
{
    public class StudentDTO
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string IDNumber { get; set; }
        public DateOnly birthDate { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string gender { get; set; }
        public string race { get; set; }
        public int universityID { get; set; }

    }
}
