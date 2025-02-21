namespace Telex_App_Performance_Monitor_Service.ServiceModels
{
    public class WebhookRequestModel
    {
        public string Username { get; set; }
        public string AppName { get; set; }
        public string Message { get; set; }
        public string PerformanceStatus { get; set; }
    }
}
