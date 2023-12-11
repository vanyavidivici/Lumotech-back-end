using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface IOrderService
{
    Task<IEnumerable<OrderDto>> GetAllOrdersAsync(OrderParameters orderParameters, bool trackChanges);
    Task<IEnumerable<OrderDto>> GetAllOrdersForUserAsync(string userId, OrderParameters orderParameters, bool trackChanges);
    Task<OrderDto> GetOrderAsync(Guid id, bool trackChanges);
    Task<OrderDto> CreateOrderAsync(string userId, OrderForCreationDto order);
    Task DeleteOrderAsync(Guid id, bool trackChanges);
    Task UpdateOrderAsync(Guid orderId, OrderForUpdateDto orderForUpdate, bool trackChanges);
}