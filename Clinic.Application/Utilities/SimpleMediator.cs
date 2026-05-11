using Clinic.Application.Exceptions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Clinic.Application.Utilities
{
    public class SimpleMediator : IMediator
    {

        private readonly IServiceProvider _serviceProvider;

        public SimpleMediator(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            // Determine the type of the validator for the request
            // var validatorType = typeof(IValidator<>).MakeGenericType(request.GetType());

            var validatorType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));

            // Try to get the validator for the request type
            // dynamic handler = _serviceProvider.GetService(handlerType); 
            var validator = _serviceProvider.GetService(validatorType);

            // If a validator exists, invoke the ValidateAsync method
            if (validator is not null)
            {
                // Use reflection to call the ValidateAsync method on the validator
                var validateMethod = validatorType.GetMethod("ValidateAsync");

                // Invoke the ValidateAsync method ('validateMethod' of the 'validator' object), we pass 'request, CancellationToken' and get the validation result
                var taskToValidate = (Task)validateMethod!.Invoke(validator, new object[] { request, CancellationToken.None })!;
                await taskToValidate;

                // Get the 'Result' property of the task to retrieve the validation result
                var result = taskToValidate.GetType().GetProperty("Result");

                // Cast the 'result' of the value of the obkect: 'taskToValidate' to 'ValidationResult' and check if it's valid
                var validationResult = (ValidationResult)result!.GetValue(taskToValidate)!;

                // If the validation result is not valid, throw a CustomValidationException with the validation errors
                if (!validationResult.IsValid)
                {
                    throw new CustomValidationException(validationResult);
                }
            }

            // Determine the type of the handler for the request
            var handlerType = typeof(IRequestHandler<,>)
                .MakeGenericType(request.GetType(), typeof(TResponse)); // We use 'MakeGenericType' to create a generic type of 'IRequestHandler' with the request type (command) and the response type (Irequest<Guid>)

            // Try to get the handler for the request type                                                                          `
            var handler = _serviceProvider.GetService(handlerType);

            // If a handler does not exist, throw a MediatorException
            if (handler is null)
            {
                throw new MediatorException($"Handler was not found for {request.GetType().Name}");
            }

            // Use reflection to call the Handle method on the handler
            var method = handlerType.GetMethod("Handle")!;

            // Invoke the 'handle' method (of the 'handler' object), we pass 'request' and get the response, then cast it to TResponse and return it
            return await (Task<TResponse>)method.Invoke(handler, new object[] { request })!;


            //  return Task.FromResult(handler(request));   

            //throw new NotImplementedException();
        }



    }
}
