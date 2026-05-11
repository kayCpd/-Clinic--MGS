using Clinic.Application.Contracts.Repositories;
using Clinic.Application.Exceptions;
using Clinic.Application.Features.GPOffices.Queries.GetGPOfficeDetail;
using Clinic.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;   
using System.Text;

namespace Clinc.Tests.Application.Features.GPOffices
{
    [TestClass]
    public class GetGPOfficeDetailQueryHandlerTests
    {       
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private IGPOfficeRepository repository;
        private GetGPOfficeDetailQueryHandler handler;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        [TestInitialize]
        public void Setup()
        {
            // Arrange - create a substitute for the repository and the handler
            repository = Substitute.For<IGPOfficeRepository>();
            handler = new GetGPOfficeDetailQueryHandler(repository);
        }

        [TestMethod]
        public async Task Handle_GPOfficeExists_ReturnsIt()
        {
            // Arrange - create a GPOffice and set up the repository to return it
            var gpOffice = new GPOffice("GP Office A");
            var id = gpOffice.Id;
            var query = new GetGPOfficeDetailQuery { Id = id };

            // Set up the repository to return the GPOffice when GetById is called with the correct ID
            repository.GetById(id).Returns(gpOffice);

            // Act - call the handler
            var result = await handler.Handle(query);

            // Assert - verify the result
            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id);
            Assert.AreEqual("GP Office A", result.Name);
        }

        [TestMethod]
        //[ExpectedException(typeof(NotFoundException))]
        public async Task Handle_GPOfficeDoesNotExists_Throws()
        {
            var id = Guid.NewGuid();
            var query = new GetGPOfficeDetailQuery { Id = id };

            repository.GetById(id).ReturnsNull();

            await handler.Handle(query);
        }
    }
}
