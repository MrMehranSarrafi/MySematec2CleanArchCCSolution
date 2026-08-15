using Microsoft.EntityFrameworkCore;
using MyCleanarchGeneral.Domain.Entities;
using MyCleanarchGeneral.Domain.IRepos;
using MyCleanarchGeneral.Infrastructure.Persistence.ApplicationContexts;

namespace MyCleanarchGeneral.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Order?> GetByIdAsync(int id)
        => await _context.Orders.FindAsync(id);

    public async Task<IEnumerable<Order>> GetAllAsync()
        => await _context.Orders.ToListAsync();

    public async Task AddAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Order order)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var order = await GetByIdAsync(id);
        if (order != null)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}
