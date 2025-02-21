using Telex_App_Performance_Monitor_Service.Constants;

namespace Telex_App_Performance_Monitor_Service.Helpers
{
    public interface IUtility
    {
        Task<HttpResponseMessage> MakeHttpRequest(object request, string baseAddress, string requestUri, HttpMethod method, Dictionary<string, string> headers = null, string mediaType = MediaTypes.JSON);
    }
}
