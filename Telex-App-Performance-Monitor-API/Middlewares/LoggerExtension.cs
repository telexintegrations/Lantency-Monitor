using Microsoft.Extensions.Logging;

namespace Telex_App_Performance_Monitor_API.Middlewares
{
    public static class LoggerExtensions
    {
        public static void InformationWithTelex(this ILogger logger, string message)
        {
            //logger.Log(LogLevel.Information, new EventId(0), message, null, (msg, ex) => msg);
        }
    }

}
