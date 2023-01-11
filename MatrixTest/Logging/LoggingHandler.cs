using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using NLog;

namespace MatrixTest
{
    public class LoggingHandler : DelegatingHandler
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Log the request
            logger.Info(DateTime.Now + Environment.NewLine + request.ToString());

            // Send the request on to the next handler
            var response = await base.SendAsync(request, cancellationToken);

            // Log the response
            logger.Info(DateTime.Now + Environment.NewLine + response.ToString());

            return response;
        }
    }
}