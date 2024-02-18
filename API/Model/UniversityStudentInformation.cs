namespace API.Model
{
    public class UniversityStudentInformation
    public class UniversityStudentInformation(int StudentID, int UniversityID)
    {
        public int StudentID { get; set; }
        public int UniversityID { get; set; }
        public int StudentID { get; set; } = StudentID;
        public int UniversityID { get; set; } = UniversityID;
    }   
}
