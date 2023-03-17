namespace OrderManagement.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IMapper mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<List<OrderForListDto>> GetOrdersAsync()
        {
            var ordersFromRepo = await _orderRepository.GetOrdersAsync();
            var ordersToReturn = _mapper.Map<List<OrderForListDto>>(ordersFromRepo);
            return ordersToReturn;
        }

        public async Task<OrderForListDto> GetOrderByIdAsync(int id)
        {
            var orderFromRepo = await _orderRepository.GetOrderByIdAsync(id);
            var orderToReturn = _mapper.Map<OrderForListDto>(orderFromRepo);
            return orderToReturn;
        }

        public async Task<BaseCommandResponse> CreateOrderAsync(OrderForCreateDto orderForCreateDto)
        {
            var response = new BaseCommandResponse();
            var validator = new OrderForCreateDtoValidator();
            var validationResult = await validator.ValidateAsync(orderForCreateDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var orderToCreate = _mapper.Map<Order>(orderForCreateDto);
            var createdOrder = await _orderRepository.CreateOrderAsync(orderToCreate);
            response.Success = true;
            response.Message = "Creation Successful";
            return response;
        }

        public async Task<BaseCommandResponse> UpdateOrderAsync(OrderForUpdateDto orderForUpdateDto)
        {
            var response = new BaseCommandResponse();
            var validator = new OrderForUpdateDtoValidator();
            var validationResult = await validator.ValidateAsync(orderForUpdateDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Updating Failed";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var orderToUpdate = _mapper.Map<Order>(orderForUpdateDto);
            var result = await _orderRepository.UpdateOrderAsync(orderToUpdate);
            response.Success = true;
            response.Message = "Updating Successful";
            return response;
        }

        public async Task<BaseCommandResponse> DeleteOrderAsync(int id)
        {
            var response = new BaseCommandResponse();
            var orderToDelete = await _orderRepository.GetOrderByIdAsync(id);

            if (orderToDelete == null)
            {
                throw new NotFoundException(nameof(Order), id);
            }

            await _orderRepository.DeleteOrderAsync(orderToDelete);
            response.Success = true;
            response.Message = "Deleting Successful";
            return response;
        }
    }
}
