using API.Model;
using API.Repository;
using API.Service.DTOs;
using System.Data;
using System.Data.SqlClient;

namespace API.Service
{
    public class BBDService(SqlConnection connection)
    {

        public object approveStudentApplication(ApplicationDTO applicationDTO) {


            try
            {
                StudentApplicationRepository applicationRepo = new StudentApplicationRepository(connection);
                StudentApplication application = applicationRepo.GetById(applicationDTO.ApplicationID);
                application.Status = applicationDTO.StatusID;
                applicationRepo.Update(application);
                return new
                {
                    message = "Application status updated successfully"
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    message = "There was an error",
                    error = ex.Message,
                    body= ex.StackTrace,
                };
            }

        }

        public object approveUniversityApplication(UniversityFundApplicationDTO applicationDTO)
        {


            try
            {
                UniversityFundApplicationRepository applicationRepo = new UniversityFundApplicationRepository(connection);
                UniversityFundApplication application = applicationRepo.GetById(applicationDTO.ApplicationID);
                application.StatusID = applicationDTO.StatusID;
                applicationRepo.Update(application);

                return new
                {
                    message = "Application status updated successfully"
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    message = "There was an error",
                    error = ex.Message,
                    body = ex.StackTrace,
                };
            }

        }

        public object getAnnualExpenditure(UniversityDTO universityDTO)
        {

            IEnumerable<University> universities = new UniversityRepository(connection).GetAll();
            IEnumerable<UniversityStudentInformation> universityStudents = new UniversityStudentInformationRepository(connection).GetAll();
            IEnumerable<StudentApplication> studentApplications = new StudentApplicationRepository(connection).GetAll();

            var Total = (from University in universities
                         join universityStudent in universityStudents on University.UniversityID equals universityStudent.UniversityID
                         join studentApplication in studentApplications on universityStudent.StudentID equals studentApplication.StudentID
                         where studentApplication.Status == 1
                         where University.Name == universityDTO.Name
                         where studentApplication.Year == universityDTO.year
                         select studentApplication.Amount).Sum();

            return new
            {
                name = universityDTO.Name,
                TotalSpent = Total,
                Year = universityDTO.year
            };
        }

        public object getTotalSpent() {
            IEnumerable<University> universities = new UniversityRepository(connection).GetAll();
            IEnumerable<BBDFund> bbdFunds = new BBDFundRepository(connection).GetAll();

            var Total = from University in universities
                        join fund in bbdFunds on University.UniversityID equals fund.UniversityID
                        select new
                        {
                            name = University.Name,
                            year = fund.FundingDate.Year,
                            amount = fund.Budget

                        };

            return Total;

        }
        
        public object distributeFunds(int Totalbudget) {

            IEnumerable<University> universities = new UniversityRepository(connection).GetAll();
            IEnumerable<int> universityIDs = findUniversityIDs(universities);
            BBDFundRepository repo = new BBDFundRepository(connection);
            DateTime dateTime = DateTime.Now;
            int budget = Totalbudget / universityIDs.Count();

            foreach (int universityID in universityIDs) {
                BBDFund fund = new BBDFund(budget,dateTime,universityID);
                repo.Add(fund);
            }

            return new
            {
                message="Funds have been distributed"
            };
        }

        public IEnumerable<int> findUniversityIDs(IEnumerable<University> universities) {
            foreach (University university in universities) {
                yield return university.UniversityID;
            }
        }




    }
}
