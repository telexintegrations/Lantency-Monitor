using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telex_App_Performance_Monitor_Service.ServiceModels
{
    public class AuthResponseModel
    {
        public string status { get; set; }
        public int status_code { get; set; }
        public string message { get; set; }
        public AuthData data { get; set; }
    }

    public class AuthData
    {
        public string access_token { get; set; }
    }
}
