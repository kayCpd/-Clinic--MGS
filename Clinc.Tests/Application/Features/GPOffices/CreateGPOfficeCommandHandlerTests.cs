using Clinic.Application.Contracts.Persistence;
using Clinic.Application.Contracts.Repositories;
using Clinic.Application.Features.GPOffices.Commands.CreateGPOffice;
using Clinic.Domain.Entities;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinc.Tests.Application.Features.GPOffices
{
    [TestClass]
    public class CreateGPOfficeCommandHandlerTests
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private IGPOfficeRepository repository;
        private IUnitOfWork unitOfWork;
        private CreateGPOfficeCommandHandler handler;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        [TestInitialize]
        public void Setup()
        {
            repository = Substitute.For<IGPOfficeRepository>();
            unitOfWork = Substitute.For<IUnitOfWork>();
            handler = new CreateGPOfficeCommandHandler(repository, unitOfWork);
        }

        [TestMethod]
        public async Task Handle_ValidCommand_ReturnsGPOfficeId()
        {
            var command = new CreateGPOfficeCommand { Name = "GP Office A" };

            var GPOffice = new GPOffice("GP Office A");

            repository.Add(Arg.Any<GPOffice>()).Returns(GPOffice);

            var result = await handler.Handle(command);

            await repository.Received(1).Add(Arg.Any<GPOffice>());
            await unitOfWork.Received(1).Commit();
            Assert.AreEqual(GPOffice.Id, result);
        }

        [TestMethod]
        public async Task Handle_WhenTheresAnError_WeRollback()
        {
            var command = new CreateGPOfficeCommand { Name = "GP Office A" };

            repository.Add(Arg.Any<GPOffice>()).Throws<Exception>();

            await Assert.ThrowsExactlyAsync<Exception>(async () =>
            {
                await handler.Handle(command);
            });

            await unitOfWork.Received(1).Rollback();
        }

    }
}
