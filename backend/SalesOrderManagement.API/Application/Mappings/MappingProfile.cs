using AutoMapper;
using SalesOrderManagement.API.Domain.Entities;
using SalesOrderManagement.API.Models;

namespace SalesOrderManagement.API.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Client, ClientDto>();
        CreateMap<ClientDto, Client>();

        CreateMap<Item, ItemDto>();
        CreateMap<ItemDto, Item>();
    }
}