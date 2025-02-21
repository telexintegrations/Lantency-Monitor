using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Telex_App_Performance_Monitor_Service.Constants;

namespace Telex_App_Performance_Monitor_Service.Helpers
{
    public class Utility: IUtility
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private HttpClient _httpClient;

        public Utility(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<HttpResponseMessage> MakeHttpRequest(object request, string baseAddress, string requestUri, HttpMethod method, Dictionary<string, string> headers = null, string mediaType = MediaTypes.JSON)
        {
            try
            {
                _httpClient = _httpClientFactory.CreateClient();
                _httpClient.BaseAddress = new Uri(baseAddress);
                if (headers != null)
                {
                    foreach (KeyValuePair<string, string> header in headers)
                    {
                        _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }

                if (method == HttpMethod.Post)
                {
                    string data = JsonConvert.SerializeObject(request);
                    HttpContent content = null;
                    switch (mediaType)
                    {
                        case MediaTypes.JSON:
                            content = new StringContent(data, Encoding.UTF8, mediaType);
                            break;
                        case MediaTypes.FormURLEncode:
                            var requestValue = JsonConvert.DeserializeObject<List<KeyValuePair<string, string>>>(data);
                            content = new FormUrlEncodedContent(requestValue);
                            break;
                        case MediaTypes.PlainText:
                            content = new StringContent(request.ToString(), Encoding.UTF8, mediaType);
                            break;
                        default:
                            break;
                    }
                    return await _httpClient.PostAsync(requestUri, content);
                }
                else if (method == HttpMethod.Get)
                {
                    return await _httpClient.GetAsync(requestUri);
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}

