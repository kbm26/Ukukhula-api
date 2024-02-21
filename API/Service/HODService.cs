using API.Model;
using API.Repository;
using API.Service.DTOs;

using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

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
                studentApplicationDTO.Comment, application.StatusID, application.StudentID, application.Year);
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
                    message = "Application failed to update",

                };
            }
        }

        public object createStudent(StudentDTO student)
        {
            try
            {
                string query = @"EXEC [dbo].[AddStudent] @firstname, @lastname, @idnumber, @birthdate,
                            @email, @phonenumber, @gender, @race, @universityID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@firstname", student.firstName);
                command.Parameters.AddWithValue("@lastname", student.lastName);
                command.Parameters.AddWithValue("@idnumber", student.IDNumber);
                command.Parameters.AddWithValue("@birthdate", student.birthDate);
                command.Parameters.AddWithValue("@email", student.email);
                command.Parameters.AddWithValue("@phonenumber", student.phoneNumber);
                command.Parameters.AddWithValue("@gender", student.gender);
                command.Parameters.AddWithValue("@race", student.race);
                command.Parameters.AddWithValue("@universityID", student.universityID);
                command.ExecuteNonQuery();

                return new
                {
                    message = "Student created succcessfully",

                };
            }
            catch (SqlException ex)
            {

                return new
                {
                    message = "Failed to create student",

                };
            }
        }

        public object createStudentApplication(StudentApplicationDTO studentApplicationDTO)
        {

            try
            {
                StudentApplicationRepository applicationRepo = new StudentApplicationRepository(connection);
                StudentApplication application = new StudentApplication(studentApplicationDTO.Grade,
                    studentApplicationDTO.Amount,studentApplicationDTO.Comment,3,studentApplicationDTO.StudentID,DateTime.Now.Year);
                applicationRepo.Add(application);

                return new
                {
                    message = "Application created successfully"
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    message = "Application failed to create",

                };
            }
        }

        public object getStudentApplication(int id)
        {

            try
            {

                StudentApplication applicant = new StudentApplicationRepository(connection).GetById(id);
                StudentInformation studentInformation = new StudentInformationRepository(connection).GetById(applicant.StudentID);
                User userInformation = new UserRepository(connection).GetById(studentInformation.UserID);
                return new {
                    name = userInformation.FirstName,
                    surname = userInformation.LastName,
                    grade = applicant.Grade,
                    year = applicant.Year,
                    amount = applicant.Amount,
                    comment = applicant.Comment,
                    status = status(applicant.StatusID)
                };

            }
            catch (Exception ex)
            {
                return new
                {
                    message = "Failed to get student application",
                    error = ex

                };
            }
        }

        public object getAllStudentApplication()
        {

            try
            {

                IEnumerable<StudentApplication> applicantions = new StudentApplicationRepository(connection).GetAll();
                IEnumerable<StudentInformation> studentInformation = new StudentInformationRepository(connection).GetAll();
                IEnumerable<User> userInformation = new UserRepository(connection).GetAll();
                return from studentinfo in studentInformation
                       join application in applicantions on studentinfo.StudentID equals application.StudentID
                       join userinfo in userInformation on studentinfo.UserID equals userinfo.UserID
                       select new

                        {
                    name = userinfo.FirstName,
                    surname = userinfo.LastName,
                    grade = application.Grade,
                    year = application.Year,
                    amount = application.Amount,
                    comment = application.Comment,
                    status = status(application.StatusID)
                };

            }
            catch (Exception ex)
            {
                return new
                {
                    message = "Failed to get student application",
                    error = ex

                };
            }
        }

        public string status(int id)
        {
            if (id == 1) { return "Approved"; }
            else if (id == 2) { return "Rejected"; }
            else if (id == 3) { return "Pending"; }
            else { return "N/A"; }
        }




    }




    
}
