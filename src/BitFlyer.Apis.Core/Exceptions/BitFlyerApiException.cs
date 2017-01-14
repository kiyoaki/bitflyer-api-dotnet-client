using System;
using System.Net;

namespace BitFlyer.Apis
{
    public class BitFlyerApiException : Exception
    {
        public string Path { get; }

        public BitFlyerApiException(string path, string message, Exception inner)
            : base(message, inner)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
            Path = path;
        }

        public BitFlyerApiException(string path, string message) :
            this(path, message, null)
        {
        }

        public HttpStatusCode HttpStatusCode { get; set; }

        public override string ToString()
        {
            return string.Format("The request to {1} has thrown an exception: {0}", base.ToString(), Path);
        }
    }
}
