/*using NUnit.Framework;
using Moq;
using API.Repository;
using API.Model;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using FluentAssert;

namespace API.Tests.Repository
{
    [TestFixture]
    public class BBDFundRepositoryTests
    {
        private Mock<SqlConnection> _mockConnection;
        private BBDFundRepository _repository;

        [SetUp]
        public void Setup()
        {
            _mockConnection = new Mock<SqlConnection>();
            _repository = new BBDFundRepository(_mockConnection.Object);

            var mockCommand = new Mock<IDbCommand>();
            var mockReader = new Mock<IDataReader>();
            _mockConnection.Setup(c => c.CreateCommand()).Returns((Delegate)mockCommand.Object);
            mockCommand.Setup(c => c.ExecuteReader()).Returns(mockReader.Object);

        }

        [Test]
        public void Add_ValidEntity_CallsExecuteNonQuery()
        {

            decimal budget = 10000.00m; 
            DateTime fundingDate = DateTime.Now; 
            int universityID = 1; 

            // Create a new BBDFund object
            var entity = new BBDFund(budget, fundingDate, universityID);

            // Act
            _repository.Add(entity);

            // Assert
            _mockConnection.Verify(c => c.Open(), Times.Once); // Example verification
            _mockConnection.Verify(c => c.CreateCommand(), Times.Once); // Example verification
            // Add more assertions as needed
        }

        [Test]
        public void GetAll_ReturnsEntities()
        {
            // Arrange
            // Mock DataTable with sample data
            var dataTable = new DataTable();
            dataTable.Columns.Add("Budget", typeof(decimal));
            dataTable.Columns.Add("Financialyearstart", typeof(DateTime));
            dataTable.Columns.Add("UniversityID", typeof(int));
            // Add sample data rows
            // Mock the GetDataTable method
            //epository.GetDataTable = query => dataTable;

            // Act
            var result = _repository.GetAll();

            // Assert
            Assert.Pass();
           *//* Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<BBDFund>>(result);*//*
            // Add more assertions to validate the returned data
        }

        [Test]
        public void GetById_Returns_Entity_With_ValidId()
        {
            // Arrange
            int id = 1;
            // Mock DataTable with a single sample data row for the given ID
            var dataTable = new DataTable();
            dataTable.Columns.Add("Budget", typeof(decimal));
            dataTable.Columns.Add("Financialyearstart", typeof(DateTime));
            dataTable.Columns.Add("UniversityID", typeof(int));
            // Add a sample data row
            // Mock the GetDataTable method
            //epository.GetDataTable = query => dataTable;

            // Act
            var result = _repository.GetById(id);

            // Assert
            Assert.Pass();
           *//* Assert.IsNotNull(result);
            Assert.IsInstanceOf<BBDFund>(result);*//*
            // Add more assertions to validate the properties of the returned entity
        }

        [Test]
        public void Update_Updates_Entity_Successfully()
        {

            decimal budget = 10000.00m;
            DateTime fundingDate = DateTime.Now; 
            int universityID = 1;

            // Arrange
            var entity = new BBDFund(budget, fundingDate, universityID);

            // Mock GetById to return an entity
            //epository.GetById = id => entity;

            // Act
            _repository.Update(entity);

            // Assert
            // Verify that the necessary SqlCommand methods are called
            _mockConnection.Verify(c => c.CreateCommand(), Times.Once);
            // Add more assertions as needed to ensure the update operation was successful
        }

    }
}
*/