using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using ModernMilkmanDemoApi.Core.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModernMilkmanDemoApi.Core.Validators
{
    public class ValidatorPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly ILogger<TRequest> _logger;

        public ValidatorPipelineBehavior(IEnumerable<IValidator<TRequest>> validators, ILogger<TRequest> logger)
        {
            _validators = validators;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Any())
                {
                    var errorBuilder = new StringBuilder();

                    foreach (var error in failures)
                    {
                        errorBuilder.AppendLine(error.ErrorMessage);
                    }

                    _logger.LogError(errorBuilder.ToString());
                    throw new InvalidCommandException($"Invalid command request - {errorBuilder.ToString()}", errorBuilder.ToString());
                }
            }

            return await next();
        }
    }
}
