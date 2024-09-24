using Shared.Domain.Exceptions;

using System.Net;

namespace Domain.Exceptions
{
    public class UnauthorizedException : HttpResponseException
    {
        private static new readonly int StatusCode = (int)HttpStatusCode.Unauthorized;

        public UnauthorizedException(string message) : base(StatusCode, message)
        {
        }

        public UnauthorizedException() : base(StatusCode, "Unauthorized user")
        {
        }
    }
}