using Newtonsoft.Json;
using Telex_App_Performance_Monitor_Service.Constants;
using Telex_App_Performance_Monitor_Service.Helpers;
using Telex_App_Performance_Monitor_Service.ServiceModels;

namespace Telex_App_Performance_Monitor_Service.Provider
{
    public class Telex: ITelex
    {
        private readonly IUtility _utility;

        public Telex(IUtility utility)
        {
            _utility = utility;
        }

        /// <summary>
        /// Login to telex im
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<bool> FeedWebhook(WebhookRequestModel model)
        {
            try
            {
                var request = new
                {
                    event_name = model.AppName,
                    message = model.Message,
                    status = model.PerformanceStatus,
                    username = model.Username,
                };

                var httpResponse = await _utility.MakeHttpRequest(request, "https://ping.telex.im", "/v1/webhooks/019519ed-229d-77e3-88fb-d84259a68068", HttpMethod.Post);
                string stringContent = await httpResponse.Content.ReadAsStringAsync();
               var response = JsonConvert.DeserializeObject<WebhookResponseModel>(stringContent);

                return true; 
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
