using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoWebAPIs.Common.ExceptionContracts
{
   public class ErrorResponse
    {

        public string Message { get; set; }

        public string ErrorCode { get; set; }

        public object[] Parameters { get; set; }
    }
}
