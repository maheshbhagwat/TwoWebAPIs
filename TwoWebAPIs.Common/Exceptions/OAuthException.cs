using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TwoWebAPIs.Common.ExceptionContracts;

namespace TwoWebAPIs.Common.Exceptions
{
    public class OAuthException : WebApiException
    {
        public OAuthException(HttpStatusCode httpCode, ErrorResponse response, string errorCode, string message, Exception exception = null, params object[] parameters)
            : base(httpCode, response, errorCode, message,exception = null,parameters)
        {

        }
    }
}
