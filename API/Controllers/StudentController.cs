using API.Model;
using API.Repository;
using Microsoft.AspNetCore.Mvc;
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
