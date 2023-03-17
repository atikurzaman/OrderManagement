using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderManagement.WebUI.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class WindowsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Gets() 
        {

        }
    }
}
