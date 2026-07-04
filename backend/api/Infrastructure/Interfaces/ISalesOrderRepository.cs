using SalesOrderManagement.API.Domain.Entities;

namespace SalesOrderManagement.API.Infrastructure.Interfaces;

public interface ISalesOrderRepository
{
    Task<List<SalesOrder>> GetAllAsync();
    Task<SalesOrder?> GetByIdAsync(int id);
    Task AddAsync(SalesOrder salesOrder);
    Task UpdateAsync(SalesOrder salesOrder);
    Task<string> GenerateOrderNumberAsync();
}