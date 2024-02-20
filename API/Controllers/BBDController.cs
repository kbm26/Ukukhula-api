﻿using API.Service.DTOs;
using API.Service;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BBDController : Controller
    {
        private readonly IConfiguration Configuration;
        public SqlConnection connection;

        public BBDController(IConfiguration configuration) {
            Configuration = configuration;
            connection = new SqlConnection(Configuration["ConnectionString"]);
            connection.Open();
        }

        [HttpPost(Name = "PostStudentFundApproval")]
        public JsonResult PostStudentFundApproval(ApplicationApprovalDTO studentApplication)
        {
            if (!ModelState.IsValid)
            {
                return Json("Bad request");
            }
            try
            {
                return Json(new BBDService(connection).approveStudentApplication(studentApplication));

            }
            catch (Exception error)
            {
                return Json(error.Message);
            }

        }

        [HttpPost(Name = "PostUniversityFundApproval")]
        public JsonResult PostUniversityFundApproval(ApplicationApprovalDTO universityFundApplication)
        {
            if (!ModelState.IsValid)
            {
                return Json("Bad request");
            }
            try
            {
                return Json(new BBDService(connection).approveUniversityApplication(universityFundApplication));

            }
            catch (Exception error)
            {
                return Json(error.Message);
            }

        }


        [HttpGet(Name = "GetUniversityAnnualExpenditure/{year}/{name}")]
        public JsonResult GetUniversityAnnualExpenditure(int year, string name )
        {
            if (!ModelState.IsValid)
            {
                return Json("Bad request");
            }
            AnnualExpenditure AnnualExpenditureyDTO = new AnnualExpenditure();
            AnnualExpenditureyDTO.year = year;
            AnnualExpenditureyDTO.Name = name;
            try
            {
                return Json(new BBDService(connection).getAnnualExpenditure(AnnualExpenditureyDTO));
            }
            catch (Exception error)
            {
                return Json(error.Message);
            }

        }


        [HttpGet(Name = "GetTotalSpentOnUniversities")]
        public JsonResult GetTotalSpentOnUniversities()
        {
            if (!ModelState.IsValid)
            {
                return Json("Bad request");
            }
            try
            {
                return Json(new BBDService(connection).getTotalSpent());

            }
            catch (Exception error)
            {
                return Json(error.Message);
            }
        }

        [HttpPost(Name = "DistributeFunds/{amount}")]

        public JsonResult DistributeFunds(int amount) {

            if (!ModelState.IsValid)
            {
                return Json("Bad request");
            }
            try
            {
                return Json(new BBDService(connection).distributeFunds(amount));

            }
            catch (Exception error)
            {
                return Json(error.Message);
            }
        }

        [HttpPost(Name = "GetUniversityFundApplication/{id}")]

        public JsonResult GetUniversityFundApplication(int id)
        {

            if (!ModelState.IsValid)
            {
                return Json("Bad request");
            }
            try
            {
                return Json(new BBDService(connection).GetUniversityFundApplication(id));

            }
            catch (Exception error)
            {
                return Json(error.Message);
            }
        }

    }

    

}
