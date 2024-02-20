using API.Model;
using API.Repository;
using API.Service.DTOs;
using System.Data.SqlClient;

namespace API.Service
{
    public class UniversityService(SqlConnection connection)
    {
        public object CreateUniversity(UniversityDTO universityDTO)
        {

            try
            {
                University university = new University(universityDTO.Name, universityDTO.Province);
                new UniversityRepository(connection).Add(university);
                
                return new
                {
                    message = "University created successfully"
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    message = "Failed to create university",

                };
            }
        }

        public object CreateUniversityFundApplication(UniversityApplicationDTO universityApplicationDTO)
        {

            try
            {
                UniversityFundApplication application = new UniversityFundApplication(universityApplicationDTO.UniversityID,DateTime.Now,
                    universityApplicationDTO.amount,3," ");
                new UniversityFundApplicationRepository(connection).Add(application);

                return new
                {
                    message = "University fund application created successfully"
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

        public object getAllUniversities() {
            try
            {
                return from university in new UniversityRepository(connection).GetAll()
                            select new
                            {
                                name = university.Name
                            };

            }
            catch (Exception ex)
            {
                return new
                {
                    message = "Failed to fetch all Universities",

                };
            }
        }




    }
}
