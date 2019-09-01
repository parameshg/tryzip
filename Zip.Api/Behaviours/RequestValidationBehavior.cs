using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Zip.Business;

namespace Zip.Api.Behaviours
{
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IZipRequest
        where TResponse : IZipResponse
    {
        private IEnumerable<IValidator<ZipRequest>> Validators { get; }

        public RequestValidationBehavior(IEnumerable<IValidator<ZipRequest>> validators)
        {
            Validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken token, RequestHandlerDelegate<TResponse> next)
        {
            TResponse result = default;

            var context = new ValidationContext(request);

            var failures = Validators.Select(i => i.Validate(context)).SelectMany(i => i.Errors).Where(i => i != null).ToList();

            if (failures.Count != 0)
            {
                result = (TResponse)Convert.ChangeType(new ZipResponse(failures), typeof(TResponse));
            }
            else
            {
                result = await next();
            }

            return result;
        }
    }
}