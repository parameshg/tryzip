using System.Collections.Generic;
using FluentValidation.Results;

namespace Zip.Business
{
    public interface IZipResponse
    {
        bool Error { get; set; }

        string Message { get; set; }

        ZipException Exception { get; set; }
    }

    public class ZipResponse : IZipResponse
    {
        public string Message { get; set; }

        public bool Error { get; set; }

        public ZipException Exception { get; set; }

        public ZipResponse()
        {
        }

        public ZipResponse(IEnumerable<ValidationFailure> failures)
        {
            Error = true;

            foreach (var failure in failures)
            {
                Message += failure.ErrorMessage + " ";
            }
        }
    }
}