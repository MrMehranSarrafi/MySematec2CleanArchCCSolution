using MyCleanarchGeneral.Application.Dto;

namespace MyCleanarchGeneral.Application.IServices;

public interface IOrderService
{
    Task<OrderDto> GetOrderAsync(int id);
    Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
    Task<int> CreateOrderAsync(string customerName, decimal amount);
    Task PayOrderAsync(int id);
    Task DeleteOrderAsync(int id);

}
