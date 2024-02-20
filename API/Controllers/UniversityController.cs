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
            


        [HttpPost(Name = "CreateUniversity")]
        public JsonResult CreateUniversity(UniversityDTO universityDTO)
        {
            if (!ModelState.IsValid)
            {
                return Json("Bad request");
            }
            try
            {
                return Json(new UniversityService(connection).CreateUniversity(universityDTO));

            }
            catch (Exception ef)
            {
                return Json(ef.Message);
            }
        }

        [HttpPost(Name = "CreateUniversityFundApplication")]
        public JsonResult CreateUniversityFundApplication(UniversityApplicationDTO universityDTO)
        {
            if (!ModelState.IsValid)
            {
                return Json("Bad request");
            }
            try
            {
                return Json(new UniversityService(connection).CreateUniversityFundApplication(universityDTO));

            }
            catch (Exception ef)
            {
                return Json(ef.Message);
            }
        }

        [HttpGet(Name = "GetAllUniversities")]
        public JsonResult GetAllUniversities() {

            if (!ModelState.IsValid)
            {
                return Json("Bad request");
            }
            try
            {
                return Json(new UniversityService(connection).getAllUniversities());

            }
            catch (Exception ef)
            {
                return Json(ef.Message);
            }

        }




    }
}
