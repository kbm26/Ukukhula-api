using API.Service.DTOs;
using API.Service;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace API.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HODController : Controller
    {
        private readonly IConfiguration Configuration;
        public SqlConnection connection;

        public HODController(IConfiguration configuration)
        {
            Configuration = configuration;
            connection = new SqlConnection(Configuration["ConnectionString"]);
            connection.Open();
        }


        [HttpPost(Name = "UpdateStudentApplication")]
        public JsonResult UpdateStudentApplication(StudentApplicationDetailsDTO studentApplicationDetailsDTO)
        {
            if (!ModelState.IsValid) { 
                return Json("Bad request");
            }
            try
            {
                return Json(new HODService(connection).updateStudent(studentApplicationDetailsDTO));

            }
            catch (Exception ef)
            {
                return Json(ef.Message);
            }
        }

        [HttpPost(Name = "CreateStudent")]
        public JsonResult CreateStudent() {

            if (!ModelState.IsValid)
            {
                return Json("Bad request");
            }
            try
            {
                return Json("pass");

            }
            catch (Exception ef)
            {
                return Json(ef.Message);
            }
        }




    }
}
