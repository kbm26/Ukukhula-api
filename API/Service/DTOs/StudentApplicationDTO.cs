﻿namespace API.Service.DTOs
{
    public class StudentApplicationDetailsDTO
    {
        public int ApplicationID { get; set; }
        public int Grade { get; set; }
        public int Amount { get; set;}
        public string Comment { get; set; }

    }

    public class StudentApplicationDTO
    {
        public int StudentID { get; set; }
        public int Grade { get; set; }
        public int Amount { get; set; }
        public string Comment { get; set; }

    }
}
