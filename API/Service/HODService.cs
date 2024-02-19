using API.Model;
using API.Repository;
using API.Service.DTOs;
using System.Data.SqlClient;

namespace API.Service
{
    public class HODService(SqlConnection connection)
    {
        public object updateStudent(StudentApplicationDetailsDTO studentApplicationDTO) {
           
            try
            {
                StudentApplicationRepository applicationRepo = new StudentApplicationRepository(connection);
                StudentApplication application = applicationRepo.GetById(studentApplicationDTO.ApplicationID);
                StudentApplication studentApplication = new StudentApplication(studentApplicationDTO.Grade, studentApplicationDTO.Amount,
                studentApplicationDTO.Comment, application.Status, application.StudentID, application.Year);
                studentApplication.ApplicationID = studentApplicationDTO.ApplicationID;
                applicationRepo.Update(studentApplication);
                return new
                {
                    message = "Application updated successfully"
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    message = "There was an error",
                    error = ex.Message
                };
            }
        }




    }
}
