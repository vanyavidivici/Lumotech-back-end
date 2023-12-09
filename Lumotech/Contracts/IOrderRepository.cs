using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAllOrdersAsync(OrderParameters orderParameters, bool trackChanges);
    Task<IEnumerable<Order>> GetAllOrdersForUserAsync(string userId, OrderParameters orderParameters, bool trackChanges);
    Task<Order> GetOrderAsync(Guid orderId, bool trackChanges);
    void CreateOrder(Order order);
    void DeleteOrder(Order order);
}