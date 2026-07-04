using Microsoft.EntityFrameworkCore;
using SalesOrderManagement.API.Domain.Entities;
using SalesOrderManagement.API.Infrastructure.Data;
using SalesOrderManagement.API.Infrastructure.Interfaces;

namespace SalesOrderManagement.API.Infrastructure.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly ApplicationDbContext _context;

    public ClientRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Client>> GetAllAsync()
    {
        return await _context.Clients
            .OrderBy(c => c.CustomerName)
            .ToListAsync();
    }

    public async Task<Client?> GetByIdAsync(int id)
    {
        return await _context.Clients
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task UpdateAsync(Client client)
    {
        _context.Clients.Update(client);
        await _context.SaveChangesAsync();
    }
}