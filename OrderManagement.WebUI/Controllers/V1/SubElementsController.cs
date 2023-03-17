using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Dtos.V1.SubElement;
using OrderManagement.Application.Services;

namespace OrderManagement.WebUI.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SubElementsController : ControllerBase
    {
        private readonly ISubElementService _subElementService;

        public SubElementsController(ISubElementService subElementService)
        {
            _subElementService = subElementService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SubElementForListDto>>> Get()
        {
            var response = await _subElementService.GetSubElementsAsync();
            return response;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubElementForListDto>> Get(int id)
        {
            var response  = await _subElementService.GetSubElementByIdAsync(id);
            return response;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SubElementForCreateDto subElementForCreateDto)
        {            
            var response = await _subElementService.CreateSubElementAsync(subElementForCreateDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] SubElementForUpdateDto subElementForUpdateDto)
        {            
            var response = await _subElementService.UpdateSubElementAsync(subElementForUpdateDto);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {            
            var response = await _subElementService.DeleteSubElementAsync(id);
            return Ok(response);
        }
    }
}
