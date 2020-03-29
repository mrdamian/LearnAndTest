using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WebApiFullframework
{
    public class WebApiDelegatingHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Content != null)
            {
                // log request body
                string requestBody = await request.Content.ReadAsStringAsync();
                Trace.WriteLine($"WebApi LogRequestAndResponseHandler fired. Request: " + request.RequestUri);
            }
            // let other handlers process the request
            var result = await base.SendAsync(request, cancellationToken);

            if (result.Content != null)
            {
                // once response body is ready, log it
                var responseBody = await result.Content.ReadAsStringAsync();
                Trace.WriteLine($"WebApi LogRequestAndResponseHandler about to response with: " + responseBody);
            }

            return result;
        }
    }
}