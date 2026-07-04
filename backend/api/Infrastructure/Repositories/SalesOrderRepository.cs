using Microsoft.EntityFrameworkCore;
using SalesOrderManagement.API.Domain.Entities;
using SalesOrderManagement.API.Infrastructure.Data;
using SalesOrderManagement.API.Infrastructure.Interfaces;

namespace SalesOrderManagement.API.Infrastructure.Repositories;

public class SalesOrderRepository : ISalesOrderRepository
{
    private readonly ApplicationDbContext _context;

    public SalesOrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<SalesOrder>> GetAllAsync()
    {
        return await _context.SalesOrders
            .Include(o => o.Client)
            .Include(o => o.SalesOrderItems)
                .ThenInclude(i => i.Item)
            .OrderByDescending(o => o.OrderDate)
            .ToListAsync();
    }

    public async Task<SalesOrder?> GetByIdAsync(int id)
    {
        return await _context.SalesOrders
            .Include(o => o.Client)
            .Include(o => o.SalesOrderItems)
                .ThenInclude(i => i.Item)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task AddAsync(SalesOrder salesOrder)
    {
        await _context.SalesOrders.AddAsync(salesOrder);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(SalesOrder salesOrder)
    {
        _context.SalesOrders.Update(salesOrder);
        await _context.SaveChangesAsync();
    }

    public async Task<string> GenerateOrderNumberAsync()
    {
        var count = await _context.SalesOrders.CountAsync();
        var nextNumber = count + 1;

        return $"SO-{DateTime.UtcNow:yyyyMMdd}-{nextNumber:0000}";
    }
}