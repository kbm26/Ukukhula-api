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
        public JsonResult CreateStudent(StudentDTO studentDTO) {

            if (!ModelState.IsValid)
            {
                return Json("Bad request");
            }
            try
            {
                return Json(new HODService(connection).createStudent(studentDTO) );

            }
            catch (Exception ef)
            {
                return Json(ef.Message);
            }
        }

        [HttpPost(Name = "CreateStudentApplication")]
        public JsonResult CreateStudentApplication(StudentApplicationDTO studentApplicationDTO) {
            if (!ModelState.IsValid)
            {
                return Json("Bad request");
            }
            try
            {
                return Json(new HODService(connection).createStudentApplication(studentApplicationDTO));

            }
            catch (Exception ef)
            {
                return Json(ef.Message);
            }
        }

        [HttpGet(Name = "GetStudentApplication/{id}")]
        public JsonResult GetStudentApplicationByID(int id)
        {
            if (!ModelState.IsValid)
            {
                return Json("Bad request");
            }
            try
            {
                return Json(new HODService(connection).getStudentApplication(id));

            }
            catch (Exception ef)
            {
                return Json(ef.Message);
            }
        }




    }
}
