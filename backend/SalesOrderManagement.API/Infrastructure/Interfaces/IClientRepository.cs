using SalesOrderManagement.API.Domain.Entities;

namespace SalesOrderManagement.API.Infrastructure.Interfaces;

public interface IClientRepository
{
    Task<List<Client>> GetAllAsync();
    Task<Client?> GetByIdAsync(int id);
    Task UpdateAsync(Client client);
}