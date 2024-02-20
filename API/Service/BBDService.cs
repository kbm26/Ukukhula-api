using API.Model;
using API.Repository;
using API.Service.DTOs;
using System.Data;
using System.Data.SqlClient;

namespace API.Service
{
    public class BBDService(SqlConnection connection)
    {

        public object approveStudentApplication(ApplicationApprovalDTO applicationDTO) {


            try
            {
                StudentApplicationRepository applicationRepo = new StudentApplicationRepository(connection);
                StudentApplication application = applicationRepo.GetById(applicationDTO.ApplicationID);
                application.StatusID = applicationDTO.StatusID;
                applicationRepo.Update(application);
                return new
                {
                    message = "Application status updated successfully",
                    id = applicationDTO.ApplicationID,
                    body = application
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

        public object approveUniversityApplication(ApplicationApprovalDTO applicationDTO)
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

        public object getAnnualExpenditure(AnnualExpenditure universityDTO)
        {

            try {
                IEnumerable<University> universities = new UniversityRepository(connection).GetAll();
                IEnumerable<UniversityStudentInformation> universityStudents = new UniversityStudentInformationRepository(connection).GetAll();
                IEnumerable<StudentApplication> studentApplications = new StudentApplicationRepository(connection).GetAll();

                var Total = (from University in universities
                             join universityStudent in universityStudents on University.UniversityID equals universityStudent.UniversityID
                             join studentApplication in studentApplications on universityStudent.StudentID equals studentApplication.StudentID
                             where studentApplication.StatusID == 1
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

        public object getTotalSpent() {

            try
            {
                IEnumerable<University> universities = new UniversityRepository(connection).GetAll();
                IEnumerable<BBDFund> bbdFunds = new BBDFundRepository(connection).GetAll();

                var Total = from University in universities
                            join fund in bbdFunds on University.UniversityID equals fund.UniversityID
                            select new
                            {
                                name = University.Name,
                                year = fund.FinancialYearStart.Year,
                                amount = fund.Budget

                            };

                return Total;
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
        
        public object distributeFunds(int Totalbudget) {

            try
            {
                IEnumerable<University> universities = new UniversityRepository(connection).GetAll();
                IEnumerable<int> universityIDs = findUniversityIDs(universities);
                BBDFundRepository BBDRepo = new BBDFundRepository(connection);
                UniversityFundApplicationRepository universityFund = new UniversityFundApplicationRepository(connection);
                DateTime dateTime = DateTime.Now;
                int budget = Totalbudget / universityIDs.Count();

                foreach (int universityID in universityIDs)
                {
                    BBDFund fund = new BBDFund(budget, dateTime, universityID);
                    UniversityFundApplication uniFund = new UniversityFundApplication(universityID, dateTime, budget, 1, "Approved");
                    BBDRepo.Add(fund);
                    universityFund.Add(uniFund);
                }

                return new
                {
                    message = "Funds have been distributed"
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

        public object GetUniversityFundApplication(int id)
        {

            try
            {

                UniversityFundApplication applicant = new UniversityFundApplicationRepository(connection).GetById(id);
                University university = new UniversityRepository(connection).GetById(applicant.UniversityID);
                return new
                {
                    name = university.Name,
                    year = applicant.FundingYear.Year,
                    amount = applicant.Amount,
                    comment = applicant.Comment,
                    status = status(applicant.StatusID)
                };


            }
            catch (Exception ex)
            {
                return new
                {
                    message = "Failed to create university fund application",

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


        public IEnumerable<int> findUniversityIDs(IEnumerable<University> universities) {
            foreach (University university in universities) {
                yield return university.UniversityID;
            }
        }





    }
}
