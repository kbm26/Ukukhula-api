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
        public ActionResult CreateUniversity(UniversityDTO universityDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad request");
            }
            try
            {
                return Ok(new UniversityService(connection).CreateUniversity(universityDTO));

            }
            catch (Exception ef)
            {
                return StatusCode(500,ef.Message);
            }
        }

        [HttpPost(Name = "CreateUniversityFundApplication")]
        public ActionResult CreateUniversityFundApplication(UniversityApplicationDTO universityDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad request");
            }
            try
            {
                return Ok(new UniversityService(connection).CreateUniversityFundApplication(universityDTO));

            }
            catch (Exception ef)
            {
                return StatusCode(500,ef.Message);
            }
        }





    }
}
