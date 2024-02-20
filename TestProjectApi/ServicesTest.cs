/*using NUnit.Framework;
using Moq;
using API.Repository;
using API.Models;
using API.Services;

namespace API.Tests.Services
{
    [TestFixture]
    public class StudentApplicationServiceTests
    {
        [Test]
        public void UpdateApplicationStatus_Successfully()
        {
            // Arrange
            var mockApplicationRepo = new Mock<IRepository<StudentApplication>>();
            var applicationService = new StudentApplicationService(mockApplicationRepo.Object);

            var applicationId = 1;
            var applicationDTO = new StudentApplicationDTO
            {
                Id = applicationId,
                StatusID = *//* set status ID *//*
            };

            var application = new StudentApplication
            {
                Id = applicationId,
                // Set other properties as needed
            };

            mockApplicationRepo.Setup(repo => repo.GetById(applicationId)).Returns(application);

            // Act
            var result = applicationService.UpdateApplicationStatus(applicationDTO);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Application status updated successfully", result.message);
            // Add more assertions as needed
        }

        [Test]
        public void UpdateApplicationStatus_Exception()
        {
            // Arrange
            var mockApplicationRepo = new Mock<IRepository<StudentApplication>>();
            var applicationService = new StudentApplicationService(mockApplicationRepo.Object);

            var applicationId = 1;
            var applicationDTO = new StudentApplicationDTO
            {
                Id = applicationId,
                StatusID = *//* set status ID *//*
            };

            var application = new StudentApplication
            {
                Id = applicationId,
                // Set other properties as needed
            };

            mockApplicationRepo.Setup(repo => repo.GetById(applicationId)).Returns(application);
            mockApplicationRepo.Setup(repo => repo.Update(It.IsAny<StudentApplication>())).Throws(new Exception("Mocked exception"));

            // Act
            var result = applicationService.UpdateApplicationStatus(applicationDTO);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("There was an error", result.message);
            // Add more assertions to validate the error handling behavior
        }
    }
}
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectApi
{
    internal class ServicesTest
    {
        public ServicesTest() { 
        Assert.Pass();
        }
    }
}
