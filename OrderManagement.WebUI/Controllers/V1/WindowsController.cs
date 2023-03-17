using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Dtos.V1.Window;
using OrderManagement.Application.Services;

namespace OrderManagement.WebUI.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WindowsController : ControllerBase
    {
        private readonly IWindowService _windowService;

        public WindowsController(IWindowService windowService)
        {
            _windowService = windowService;
        }

        [HttpGet]
        public async Task<ActionResult<List<WindowForListDto>>> Get()
        {
            var response = await _windowService.GetWindowsAsync();
            return response;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WindowForListDto>> Get(int id)
        {
            var response = await _windowService.GetWindowByIdAsync(id);
            return response;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] WindowForCreateDto windowForCreateDto)
        {
            var response = await _windowService.CreateWindowAsync(windowForCreateDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] WindowForUpdateDto windowForUpdateDto)
        {
            var response = await _windowService.UpdateWindowAsync(windowForUpdateDto);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _windowService.DeleteWindowAsync(id);
            return Ok(response);
        }
    }
}
}
