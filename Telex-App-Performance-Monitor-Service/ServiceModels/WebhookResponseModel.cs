namespace Telex_App_Performance_Monitor_Service.ServiceModels
{
    public class WebhookResponseModel   //can later be factorized with aithresponsemodel since they contain common properties
    {
        public string status { get; set; }
        public int status_code { get; set; }
        public string message { get; set; }
    }
}
