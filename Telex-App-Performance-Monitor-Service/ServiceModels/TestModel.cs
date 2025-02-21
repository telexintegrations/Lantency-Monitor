using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telex_App_Performance_Monitor_Service.ServiceModels
{
    public class TestModel
    {
        [Required]
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Loation { get; set; }
        public string Gender { get; set; }
        public string Username { get; set; }
    }
}
