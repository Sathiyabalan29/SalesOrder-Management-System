using AutoMapper;
using SalesOrderManagement.API.Application.Interfaces;
using SalesOrderManagement.API.Infrastructure.Interfaces;
using SalesOrderManagement.API.Models;

namespace SalesOrderManagement.API.Application.Services;

public class ItemService : IItemService
{
    private readonly IItemRepository _itemRepository;
    private readonly IMapper _mapper;

    public ItemService(IItemRepository itemRepository, IMapper mapper)
    {
        _itemRepository = itemRepository;
        _mapper = mapper;
    }

    public async Task<List<ItemDto>> GetAllAsync()
    {
        var items = await _itemRepository.GetAllAsync();
        return _mapper.Map<List<ItemDto>>(items);
    }

    public async Task<ItemDto?> GetByIdAsync(int id)
    {
        var item = await _itemRepository.GetByIdAsync(id);

        if (item == null)
        {
            return null;
        }

        return _mapper.Map<ItemDto>(item);
    }
}