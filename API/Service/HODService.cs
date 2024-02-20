using API.Model;
using API.Repository;
using API.Service.DTOs;
using System.Collections;
using System.Collections.Generic;
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

        public object getAllApprovedStudents(string UniversityName, int year) {
            try {
                IEnumerable<University> universities = new UniversityRepository(connection).GetAll();
                IEnumerable<UniversityStudentInformation> universityStudents = new UniversityStudentInformationRepository(connection).GetAll();
                IEnumerable<StudentApplication> studentApplications = new StudentApplicationRepository(connection).GetAll();
                IEnumerable <StudentInformation> studentInformation = new StudentInformationRepository(connection).GetAll();
                IEnumerable<User> users = new UserRepository(connection).GetAll();

                /*     where studentApplication.Status == 1
                       where University.Name == UniversityName
                       where studentApplication.Year == year
                join student in studentInformation on studentApplication.StudentID equals student.StudentID
                join user in users on student.UserID equals user.UserID
                */

                var query =  from University in universities
                       join universityStudent in universityStudents on University.UniversityID equals universityStudent.UniversityID
                       join studentApplication in studentApplications on universityStudent.StudentID equals studentApplication.StudentID

                       select new
                       {
                           Student = studentApplication

                       };
                return query;
                                                
            }catch (Exception ex)
            {
                return new
                {
                    message = ex.Message,

                };
            }
        }



    }
}
