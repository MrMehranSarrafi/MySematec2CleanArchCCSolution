using MyCleanarchGeneral.Application.Dto;
using MyCleanarchGeneral.Application.IServices;
using MyCleanarchGeneral.Domain.Entities;
using MyCleanarchGeneral.Domain.IRepos;

namespace MyCleanarchGeneral.Application.Services;

public class OrderService : IOrderService
{
    readonly IOrderRepository _orderRepository;
    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public async Task<OrderDto> GetOrderAsync(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        if (order == null)
            throw new KeyNotFoundException($"Order {id} not found");
        return MapToDto(order);
    }
    public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
    {
       var orders = await _orderRepository.GetAllAsync();
        return orders.Select(MapToDto);
    }

    public async Task<int> CreateOrderAsync(string customerName, decimal amount)
    {

        if (amount <= 0)
            throw new ArgumentException("Amount must be positive");
        var order = new Order(customerName, amount);
        await _orderRepository.AddAsync(order);
        return order.Id;

    }
    public async Task PayOrderAsync(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        if (order == null)
            throw new KeyNotFoundException($"Order {id} not found");

        order.MarkAsPaid();
        await _orderRepository.UpdateAsync(order);
    }

    public async Task DeleteOrderAsync(int id)
    {
        await _orderRepository.DeleteAsync(id);
    }
    private static OrderDto MapToDto(Order order)
    {
        return new OrderDto
        {
            Id = order.Id,
            CustomerName = order.CustomerName,
            TotalAmount = order.TotalAmount,
            CreatedAt = order.CreatedAt,
            IsPaid = order.IsPaid
        };
    }

   
   

   
}
