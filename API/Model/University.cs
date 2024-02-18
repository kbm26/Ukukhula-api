namespace API.Model
{
    public class University(string Name, int ProvinceID)
    {

        public int UniversityID { get; set; }
        public string Name { get; set; } = Name;
        public int ProvinceID { get; set; } = ProvinceID;


    }
}
