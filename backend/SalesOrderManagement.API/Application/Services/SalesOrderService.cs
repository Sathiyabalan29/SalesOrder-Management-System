using SalesOrderManagement.API.Application.Interfaces;
using SalesOrderManagement.API.Application.Mappings;
using SalesOrderManagement.API.Domain.Entities;
using SalesOrderManagement.API.Infrastructure.Interfaces;
using SalesOrderManagement.API.Models;

namespace SalesOrderManagement.API.Application.Services;

public class SalesOrderService : ISalesOrderService
{
    private readonly ISalesOrderRepository _salesOrderRepository;
    private readonly IClientRepository _clientRepository;
    private readonly IItemRepository _itemRepository;

    public SalesOrderService(
        ISalesOrderRepository salesOrderRepository,
        IClientRepository clientRepository,
        IItemRepository itemRepository)
    {
        _salesOrderRepository = salesOrderRepository;
        _clientRepository = clientRepository;
        _itemRepository = itemRepository;
    }

    public async Task<List<SalesOrderListDto>> GetAllAsync()
    {
        var orders = await _salesOrderRepository.GetAllAsync();

        return orders
            .Select(SalesOrderMapper.ToListDto)
            .ToList();
    }

    public async Task<SalesOrderResponseDto?> GetByIdAsync(int id)
    {
        var order = await _salesOrderRepository.GetByIdAsync(id);

        if (order == null)
        {
            return null;
        }

        return SalesOrderMapper.ToResponseDto(order);
    }

    public async Task<SalesOrderResponseDto> CreateAsync(SalesOrderSaveDto dto)
    {
        await ValidateClientAndUpdateAsync(dto);
        await ValidateItemsAsync(dto);

        var salesOrder = new SalesOrder
        {
            OrderNumber = await _salesOrderRepository.GenerateOrderNumberAsync(),
            OrderDate = DateTime.UtcNow,
            ClientId = dto.ClientId,
            SalesOrderItems = CreateSalesOrderItems(dto)
        };

        await _salesOrderRepository.AddAsync(salesOrder);

        var savedOrder = await _salesOrderRepository.GetByIdAsync(salesOrder.Id);

        return SalesOrderMapper.ToResponseDto(savedOrder!);
    }

    public async Task<SalesOrderResponseDto?> UpdateAsync(int id, SalesOrderSaveDto dto)
    {
        var salesOrder = await _salesOrderRepository.GetByIdAsync(id);

        if (salesOrder == null)
        {
            return null;
        }

        await ValidateClientAndUpdateAsync(dto);
        await ValidateItemsAsync(dto);

        salesOrder.ClientId = dto.ClientId;
        salesOrder.SalesOrderItems.Clear();

        foreach (var item in CreateSalesOrderItems(dto))
        {
            salesOrder.SalesOrderItems.Add(item);
        }

        await _salesOrderRepository.UpdateAsync(salesOrder);

        var updatedOrder = await _salesOrderRepository.GetByIdAsync(salesOrder.Id);

        return SalesOrderMapper.ToResponseDto(updatedOrder!);
    }

    private async Task ValidateClientAndUpdateAsync(SalesOrderSaveDto dto)
    {
        var client = await _clientRepository.GetByIdAsync(dto.ClientId);

        if (client == null)
        {
            throw new KeyNotFoundException("Client not found.");
        }

        client.CustomerName = dto.CustomerName;
        client.Address = dto.Address;
        client.City = dto.City;
        client.PostCode = dto.PostCode;

        await _clientRepository.UpdateAsync(client);
    }

    private async Task ValidateItemsAsync(SalesOrderSaveDto dto)
    {
        var itemIds = dto.Items
            .Select(item => item.ItemId)
            .Distinct()
            .ToList();

        var items = await _itemRepository.GetByIdsAsync(itemIds);

        if (items.Count != itemIds.Count)
        {
            throw new KeyNotFoundException("One or more items were not found.");
        }
    }

    private static List<SalesOrderItem> CreateSalesOrderItems(SalesOrderSaveDto dto)
    {
        return dto.Items.Select(item => new SalesOrderItem
        {
            ItemId = item.ItemId,
            Note = item.Note,
            Quantity = item.Quantity,
            TaxRate = item.TaxRate
        }).ToList();
    }
}