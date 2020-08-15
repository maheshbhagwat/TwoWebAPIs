using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TwoWebAPIs.SelfHosting
{
    public class GlobalErrorHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                return base.SendAsync(request, cancellationToken);
            }
            catch (Exception ex)
            {
                var responseMessage = request.CreateErrorResponse(System.Net.HttpStatusCode.InternalServerError, ex.Message);
                var tsc = new TaskCompletionSource<HttpResponseMessage>();
                tsc.SetResult(responseMessage);
                return tsc.Task;
            }
        }
    }
}
