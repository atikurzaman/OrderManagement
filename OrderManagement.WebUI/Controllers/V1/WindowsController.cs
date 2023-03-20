using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Dtos.V1.Window;
using OrderManagement.Application.Services;
using System.Net;

namespace OrderManagement.WebUI.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WindowsController : ControllerBase
    {
        private readonly IWindowService _windowService;
        private readonly ILogger<OrdersController> _logger;

        public WindowsController(IWindowService windowService, ILogger<OrdersController> logger)
        {
            _windowService = windowService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<WindowForListDto>>> Get()
        {            
            try
            {
                var windows = await _windowService.GetWindowsAsync();                
                if (windows == null)
                {
                    return NotFound();
                }
                return Ok(windows);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WindowForListDto>> Get(int id)
        {
            try
            {
                var window = await _windowService.GetWindowByIdAsync(id);
                if (window == null)
                {
                    return NotFound();
                }
                return Ok(window);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] WindowForCreateDto windowForCreateDto)
        {
            try
            {
                var response = await _windowService.CreateWindowAsync(windowForCreateDto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] WindowForUpdateDto windowForUpdateDto)
        {
            try
            {
                var response = await _windowService.UpdateWindowAsync(windowForUpdateDto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await _windowService.DeleteWindowAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}

