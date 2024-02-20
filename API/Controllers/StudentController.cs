using API.Repository;
﻿using API.Model;
using API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using API.Repositories;


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
                User s = new Model.User("Kyle", "Moodley", 1, 1);
                s.UserID = 11;

                new UserRepository(connString).Update(s);


                return Json("worked");

            }
            catch (Exception ef)
            {
                return Json(ef.Message);
            }
            finally { connString.Close(); }
            
            
        }


    }
}
