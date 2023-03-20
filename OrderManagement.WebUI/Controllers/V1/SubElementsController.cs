using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Dtos.V1.SubElement;
using OrderManagement.Application.Services;
using System.Net;

namespace OrderManagement.WebUI.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SubElementsController : ControllerBase
    {
        private readonly ISubElementService _subElementService;
        private readonly ILogger<OrdersController> _logger;

        public SubElementsController(ISubElementService subElementService, ILogger<OrdersController> logger)
        {
            _subElementService = subElementService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<SubElementForListDto>>> Get()
        {
            try
            {
                var subElements = await _subElementService.GetSubElementsAsync();
                if (subElements == null)
                {
                    return NotFound();
                }

                return Ok(subElements);                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubElementForListDto>> Get(int id)
        {
            try
            {
                var subElement = await _subElementService.GetSubElementByIdAsync(id);
                if (subElement == null)
                {
                    return NotFound();
                }

                return Ok(subElement);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SubElementForCreateDto subElementForCreateDto)
        {
            try
            {
                var response = await _subElementService.CreateSubElementAsync(subElementForCreateDto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] SubElementForUpdateDto subElementForUpdateDto)
        {
            try
            {
                var response = await _subElementService.UpdateSubElementAsync(subElementForUpdateDto);
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
                var response = await _subElementService.DeleteSubElementAsync(id);
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
