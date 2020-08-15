using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TwoWebAPIs.Common.ExceptionContracts;

namespace TwoWebAPIs.Common
{
    public class WebApiException : Exception
    {
        private const string ERROR_CODE = "ERROR_CODE";
        private const string HTTP_STATUS_CODE = "HTTP_STATUS_CODE";

        private string _message;

        public ErrorResponse ErrorResponse { get; private set; }

        public object[] Parameters { get; private set; }

        public string Code { get; private set; }

        public HttpStatusCode HttpCode { get; private set; }

        public WebApiException(HttpStatusCode httpCode, ErrorResponse response, string errorCode, string message, Exception exception = null, params object[] parameters)
       : base(message, exception)
        {
            this._message = message;
            this.HttpCode = httpCode;
            this.Code = errorCode;
            this.Parameters = parameters;
            this.ErrorResponse = response;
        }


        public override string Message
        {
            get
            {
                return string.Format("Type: '{0}', Code: '{1}', Message: '{2}'", this.GetType().Name, this.Code ?? string.Empty, this._message ?? string.Empty);
            }
        }


    }
}
