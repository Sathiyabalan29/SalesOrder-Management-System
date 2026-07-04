using Microsoft.EntityFrameworkCore;
using SalesOrderManagement.API.Domain.Entities;
using SalesOrderManagement.API.Infrastructure.Data;
using SalesOrderManagement.API.Infrastructure.Interfaces;

namespace SalesOrderManagement.API.Infrastructure.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly ApplicationDbContext _context;

    public ItemRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Item>> GetAllAsync()
    {
        return await _context.Items
            .OrderBy(i => i.ItemCode)
            .ToListAsync();
    }

    public async Task<Item?> GetByIdAsync(int id)
    {
        return await _context.Items
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<List<Item>> GetByIdsAsync(List<int> ids)
    {
        return await _context.Items
            .Where(i => ids.Contains(i.Id))
            .ToListAsync();
    }
}