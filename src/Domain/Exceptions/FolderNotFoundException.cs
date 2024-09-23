using Shared.Domain.Exceptions;

using System.Net;

namespace Domain.Exceptions
{
    public class FolderNotFoundException : HttpResponseException
    {
        private static new readonly int StatusCode = (int)HttpStatusCode.NotFound;

        public FolderNotFoundException(object? value) : base(StatusCode, value)
        {
        }

        public FolderNotFoundException() : base(StatusCode, "Folder doesn't exist")
        {
        }
    }
}