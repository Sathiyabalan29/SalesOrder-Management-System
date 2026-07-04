using SalesOrderManagement.API.Domain.Entities;

namespace SalesOrderManagement.API.Infrastructure.Interfaces;

public interface IItemRepository
{
    Task<List<Item>> GetAllAsync();
    Task<Item?> GetByIdAsync(int id);
    Task<List<Item>> GetByIdsAsync(List<int> ids);
}