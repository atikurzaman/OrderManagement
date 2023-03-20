using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Dtos.V1.Order;
using OrderManagement.Application.Services;
using System.Net;

namespace OrderManagement.WebUI.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IOrderService orderService, ILogger<OrdersController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderForListDto>>> Get()
        {
            try
            {
                var orders = await _orderService.GetOrdersAsync();
                if (orders == null)
                {
                    return NotFound();
                }

                return Ok(orders);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderForListDto>> Get(int id)
        {
            try
            {
                var order = await _orderService.GetOrderByIdAsync(id);
                if (order == null)
                {
                    return NotFound();
                }
                return Ok(order);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }            
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] OrderForCreateDto OrderForCreateDto)
        {
            try
            {
                var response = await _orderService.CreateOrderAsync(OrderForCreateDto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] OrderForUpdateDto OrderForUpdateDto)
        {
            try
            {
                var response = await _orderService.UpdateOrderAsync(OrderForUpdateDto);
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
                var response = await _orderService.DeleteOrderAsync(id);
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

