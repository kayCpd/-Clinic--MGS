using Clinic.Application.Contracts.Persistence;
using Clinic.Application.Contracts.Repositories;
using Clinic.Application.Utilities;
using Clinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Application.Features.GPOffices.Commands.CreateGPOffice
{
    public class CreateGPOfficeCommandHandler : IRequestHandler<CreateGPOfficeCommand, Guid>
    {
        private readonly IGPOfficeRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        // private readonly IValidator<CreateGPOfficeCommand> _validator;

        public CreateGPOfficeCommandHandler(IGPOfficeRepository repository, IUnitOfWork unitOfWork)
        //IValidar<CreateGPOfficeCommand> validator)
        {
            this._repository = repository;
            this._unitOfWork = unitOfWork;
            //  this._validator = validator;
        }
        public async Task<Guid> Handle(CreateGPOfficeCommand command)
        {
            //var validationResult = await _validator.ValidateAsync(command);
            //if (!validationResult.IsValid)
            //{
            //    throw new CustomValidationException(validationResult);

            //    // throw new ValidationException(string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage)));

            //}

            var GPOffice = new GPOffice(command.Name);
            try
            {
                var result = await _repository.Add(GPOffice);
                await _unitOfWork.Commit();
                return result.Id;
            }
            catch (Exception)
            {
                await _unitOfWork.Rollback();
                throw;
            }
        }
    }
}