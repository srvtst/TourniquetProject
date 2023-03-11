﻿using FluentValidation;
using MediatR;

namespace Tourniquet.Application.Features.Validations
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var errors = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(e => e != null)
                .ToList();

            if (errors.Count != 0) 
            {
                throw new ValidationException(errors);
            }

            TResponse response = await next();
            return response;
        }
    }
}