using System;

namespace Zip.Business
{
    public class ZipException : Exception
    {
        public ZipException()
        {
        }

        public ZipException(string message)
            : base(message)
        {
        }

        public ZipException(string message, Exception exception)
            : base(message, exception)
        {
        }

        public ZipException(Exception exception)
            : base("Error occuered while processing request", exception)
        {
        }
    }
}