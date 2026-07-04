using SalesOrderManagement.API.Models;

namespace SalesOrderManagement.API.Application.Interfaces;

public interface ISalesOrderService
{
    Task<List<SalesOrderListDto>> GetAllAsync();
    Task<SalesOrderResponseDto?> GetByIdAsync(int id);
    Task<SalesOrderResponseDto> CreateAsync(SalesOrderSaveDto dto);
    Task<SalesOrderResponseDto?> UpdateAsync(int id, SalesOrderSaveDto dto);
}