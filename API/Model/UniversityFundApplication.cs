namespace API.Model
{
    public class UniversityFundApplication
    {
        public int ApplicationID { get; }
        public string UniversityID { get; set; }
        public DateTime FundingYear { get; set; }
        public int Amount { get; set; }
        public int StatusID { get; set; }
        public String Comment { get; set; }


    }
}
