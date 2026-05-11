using Clinic.Application.Contracts.Repositories;
//using Clinic.Application.Features.GPOffices.Queries.GetGPOfficeList;
using Clinic.Application.Features.GPOffices.Queries.GetGPOfficesList;

//using Clinic.Application.Features.GPOffices.Queries.GetGPOfficeList;
using Clinic.Application.Features.GPOffices.Queries.GetGPOfficesList;
using Clinic.Domain.Entities;

using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinc.Tests.Application.Features.GPOffices
{
    [TestClass]
    public class GetGPOfficesListQueryHandlerTests
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private IGPOfficeRepository repository;
        private GetGPOfficesListQueryHandler handler;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.


        [TestInitialize]
        public void Setup()
        {
            repository = Substitute.For<IGPOfficeRepository>();
            handler = new GetGPOfficesListQueryHandler(repository);
        }

        [TestMethod]
        public async Task Handle_WhenThereAreGPOffices_ReturnsListOfThem()
        {
            var GPOffices = new List<GPOffice>
            {
                new GPOffice("GP Office A"),
                new GPOffice("GP Office B")
            };

            repository.GetAll().Returns(GPOffices);

            var expected = GPOffices.Select(d => new GPOfficesListDTO
            {
                Id = d.Id,
                Name = d.Name
            }).ToList();

            var result = await handler.Handle(new GetGPOfficesListQuery());

            Assert.AreEqual(expected.Count, result.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].Name, result[i].Name);
            }
        }

        [TestMethod]
        public async Task Handle_WhenThereAreNoGPOffices_ItReturnsAnEmptyList()
        {
            repository.GetAll().Returns(new List<GPOffice>());

            var result = await handler.Handle(new GetGPOfficesListQuery());

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

    }
}
