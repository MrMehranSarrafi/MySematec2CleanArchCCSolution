 
// API/Controllers/OrdersController.cs
using Microsoft.AspNetCore.Mvc;
using MyCleanarchGeneral.Application.Dto;
using MyCleanarchGeneral.Application.IServices;

namespace MyCleanarchGeneralProj.WebUI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("{id}")]///api/Orders/10
    //[HttpGet("GetOrder/{id}")]           /api/Orders/GetOrder/10
    public async Task<ActionResult<OrderDto>> GetOrder(int id)
    {
        var order = await _orderService.GetOrderAsync(id);
        return Ok(order);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetAll()
    {
        var orders = await _orderService.GetAllOrdersAsync();
        return Ok(orders);
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateOrder(string customerName, decimal amount)
    {
        var id = await _orderService.CreateOrderAsync(customerName, amount);
        return CreatedAtAction(nameof(GetOrder), new { id }, id);
    }

    [HttpPut("{id}/pay")]
    public async Task<IActionResult> PayOrder(int id)
    {
        await _orderService.PayOrderAsync(id);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        await _orderService.DeleteOrderAsync(id);
        return NoContent();
    }
}
