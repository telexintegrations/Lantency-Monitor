using Telex_App_Performance_Monitor_Service.Provider;

namespace Telex_App_Performance_Monitor_API.Middlewares
{
    public class RequestLatencyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLatencyMiddleware> _logger;
        private readonly ITelex _telex;

        public RequestLatencyMiddleware(RequestDelegate next, ILogger<RequestLatencyMiddleware> logger, ITelex telex)
        {
            _next = next;
            _logger = logger;
            _telex = telex;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var startTime = DateTime.UtcNow;

            // Call the next middleware in the pipeline
            await _next(context);

            var endTime = DateTime.UtcNow;
            var latency = endTime - startTime;
            var statusCode = context.Response.StatusCode;
            var requestPath = context.Request.Path;

            // Log the latency
            _logger.LogInformation($"Request took {latency.TotalMilliseconds} ms.");
            await _telex.FeedWebhook(new Telex_App_Performance_Monitor_Service.ServiceModels.WebhookRequestModel
            { 
                Username = "mubarak toye", //to be replaced with Afiz's own
                AppName = requestPath,
                Message = $"Request took {latency.TotalMilliseconds} ms.",
                PerformanceStatus = statusCode == 200 ? "success": "error"
            });
        }
    }
}
