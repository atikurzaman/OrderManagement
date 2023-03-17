using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Dtos.V1.Order;
using OrderManagement.Application.Services;

namespace OrderManagement.WebUI.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderForListDto>>> Get()
        {
            var response = await _orderService.GetOrdersAsync();
            return response;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderForListDto>> Get(int id)
        {
            var response = await _orderService.GetOrderByIdAsync(id);
            return response;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] OrderForCreateDto OrderForCreateDto)
        {
            var response = await _orderService.CreateOrderAsync(OrderForCreateDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] OrderForUpdateDto OrderForUpdateDto)
        {
            var response = await _orderService.UpdateOrderAsync(OrderForUpdateDto);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _orderService.DeleteOrderAsync(id);
            return Ok(response);
        }
    }
}

