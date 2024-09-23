using Shared.Domain.Exceptions;

using System.Net;

namespace Domain.Exceptions
{
    public class UserNotOwnerFolderException : HttpResponseException
    {
        private static new readonly int StatusCode = (int)HttpStatusCode.Unauthorized;

        public UserNotOwnerFolderException(string message) : base(StatusCode, message)
        {
        }

        public UserNotOwnerFolderException() : base(StatusCode, "User doesn't own the folder")
        {
        }
    }
}