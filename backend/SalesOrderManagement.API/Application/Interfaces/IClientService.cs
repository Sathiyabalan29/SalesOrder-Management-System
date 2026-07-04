using SalesOrderManagement.API.Models;

namespace SalesOrderManagement.API.Application.Interfaces;

public interface IClientService
{
    Task<List<ClientDto>> GetAllAsync();
    Task<ClientDto?> GetByIdAsync(int id);
}