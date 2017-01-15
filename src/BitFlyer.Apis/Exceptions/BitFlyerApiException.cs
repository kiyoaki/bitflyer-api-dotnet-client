using System;

namespace BitFlyer.Apis
{
    public class BitFlyerApiException : Exception
    {
        public string Path { get; }

        public Error ErrorResponse { get; }

        public BitFlyerApiException(string path, string message, Error errorResponse, Exception inner)
            : base(message, inner)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
            Path = path;
            ErrorResponse = errorResponse;
        }

        public BitFlyerApiException(string path, string message) :
            this(path, message, null, null)
        {
        }

        public BitFlyerApiException(string path, string message, Error errorResponse) :
            this(path, message, errorResponse, null)
        {
        }

        public BitFlyerApiException(string path, string message, Exception inner) :
            this(path, message, null, inner)
        {
        }

        public override string ToString()
        {
            return $"The request to {Path} has thrown an exception: {base.ToString()}";
        }
    }
}
