using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telex_App_Performance_Monitor_Service.Provider;
using Telex_App_Performance_Monitor_Service.ServiceModels;

namespace Telex_App_Performance_Monitor_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitorController : ControllerBase
    {
        private readonly ITelex _telex;

        public MonitorController(ITelex telex)
        {
            _telex = telex;
        }

        [HttpPost("register-user")]
        public async Task<IActionResult> RegisterUser(TestModel model)
        {
            return Ok($"Welcome {model.Firstname}  {model.Lastname} from {model.Loation}");
        }

        [HttpPost("get-user-by-id")]
        public async Task<IActionResult> RegisterUser(int id)
        {
            if(id == 1)
            {
                return Ok(new
                {
                    firstname = "Bilal",
                    lastname = "Omar",
                    location = "Lagos",
                    gender = "Male"
                });
            }
            else
            {
                return NotFound();
            }
        }
    }
}
