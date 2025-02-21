using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telex_App_Performance_Monitor_Service.ServiceModels;

namespace Telex_App_Performance_Monitor_Service.Provider
{
    public interface ITelex
    {
        Task<bool> FeedWebhook(WebhookRequestModel model);
    }
}
