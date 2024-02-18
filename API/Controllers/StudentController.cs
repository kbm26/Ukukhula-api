using API.Repository;
﻿using API.Model;
using API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private IConfiguration Configuration;

        public StudentController(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        [HttpGet(Name = "GetFund")]
        public JsonResult Get() //GET
        {            
            SqlConnection connString = new SqlConnection("Server=tcp:ukukhulabursaryfund.database.windows.net,1433;Initial Catalog=UkukhulaDatabase;Persist Security Info=False;User ID=Admin3;Password=Database1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            connString.Open();
            try
            {
                new BBDFundRepository(connString).Add(new Model.BBDFund(1, new DateTime(2022, 2, 15, 10, 30, 0), 2));
                return Json("worked");
                IEnumerable < University >  unis = new UniversityRepository(connString).GetAll();
                IEnumerable<UniversityFundApplication> unifunds = new UniversityFundApplicationRepository(connString).GetAll();

                var query = from University in unis
                            join Unifund in unifunds on University.UniversityID equals Unifund.UniversityID
                            where University.Name == "University of Cape Town"
                            where Unifund.FundingYear.Date.Year == 2020
                            select new
                            {
                                name = University.Name,
                                budget = Unifund.Amount,
                                year = Unifund.FundingYear.Date.Year
                            };
                return Json(query);

            }
            catch (Exception ef)
            {
                return Json(ef.Message);
            }
            finally { connString.Close(); }
            
            
        }


    }
}
