using SalesOrderManagement.API.Models;

namespace SalesOrderManagement.API.Application.Interfaces;

public interface IItemService
{
    Task<List<ItemDto>> GetAllAsync();
    Task<ItemDto?> GetByIdAsync(int id);
}