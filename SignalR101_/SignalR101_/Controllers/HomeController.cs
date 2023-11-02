using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR101_.Bussiness;
using SignalR101_.Hubs;

namespace SignalR101_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        //If we need a business layer we use this
        private readonly MyBusiness mybussines;

        //If we do not need  a business operation, IhubContext will be enough.
        private readonly IHubContext<Myhub> hubContext;

        public HomeController(MyBusiness mybussines, IHubContext<Myhub> hubContext)
        {
            this.mybussines = mybussines;
            this.hubContext = hubContext;
        }

        [HttpGet("{message}")]
        public async Task<IActionResult> Index(string message)
        {
            await mybussines.SendMessageAsync(message);
            return Ok();
        }

       
    }
}
