using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebClient.Exceptions
{
    public class WebClientException
        : Exception
    {
        public HttpStatusCode StatusCode { get; }
        public int ErrorCode { get; set; }
        public IDictionary<string, string[]> ValidationErrors { get; set; }

        public WebClientException(HttpStatusCode statusCode, string message)
            : base(message)
        {
            StatusCode = statusCode;
        }

        public WebClientException(HttpStatusCode statusCode, string message, Exception innerException)
            : base(message, innerException)
        {
            StatusCode = statusCode;
        }

        protected WebClientException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
