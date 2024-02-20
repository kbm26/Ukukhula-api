using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace TestProject
{
    public class ApiTests
    {
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {

            _client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7297/") 
            };
        }

        [Test]
        public async Task TestGetStudents()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "api/Student");

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }

    public class DatabaseTests
    {
        private SqlConnection _connection;

        [SetUp]
        public void Setup()
        {
            // Setup SqlConnection for testing against your database
            string connectionString = "Server=tcp:ukukhulabursaryfund.database.windows.net,1433;Initial Catalog=UkukhulaDatabase;Persist Security Info=False;User ID=Admin3;Password=Database1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }

        [Test]
        public async Task TestGetStudentById()
        {
            // Arrange
            int studentId = 1; // Replace with the ID of the student you're testing
            string query = $"SELECT * FROM StudentInformation WHERE StudentID= {studentId}";

            // Act
            using var command = new SqlCommand(query, _connection);
            using var reader = await command.ExecuteReaderAsync();
            // Assert
            Assert.That(reader.HasRows, Is.True, $"No student found with ID {studentId}");
        }

    }
}