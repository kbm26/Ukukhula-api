using API.Repository;
﻿using API.Model;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using API.Service.DTOs;
using API.Service;


namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UniversityController : Controller
    {
        private readonly IConfiguration Configuration;
        public SqlConnection connection;

        public UniversityController(IConfiguration configuration)
        {
            Configuration = configuration;
            connection = new SqlConnection(Configuration["ConnectionString"]);
            connection.Open();
        }
            


        [HttpPost(Name = "PostNewStudent")]
        public JsonResult updateStudent(StudentApplicationDetailsDTO studentApplicationDetailsDTO)
        {
            if (!ModelState.IsValid)
            {
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





        }
}
