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


        [HttpPost(Name = "UpdateStudent")]
        public JsonResult updateStudent(StudentApplicationDetailsDTO studentApplicationDetailsDTO)
        {
            try
            {
                return Json(new HODService(connection).updateStudent(studentApplicationDetailsDTO));

            }
            catch (Exception ef)
            {
                return Json(ef.Message);
            }
        }


    }
}
