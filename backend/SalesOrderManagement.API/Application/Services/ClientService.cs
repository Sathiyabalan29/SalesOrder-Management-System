using AutoMapper;
using SalesOrderManagement.API.Application.Interfaces;
using SalesOrderManagement.API.Infrastructure.Interfaces;
using SalesOrderManagement.API.Models;

namespace SalesOrderManagement.API.Application.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;

    public ClientService(IClientRepository clientRepository, IMapper mapper)
    {
        _clientRepository = clientRepository;
        _mapper = mapper;
    }

    public async Task<List<ClientDto>> GetAllAsync()
    {
        var clients = await _clientRepository.GetAllAsync();
        return _mapper.Map<List<ClientDto>>(clients);
    }

    public async Task<ClientDto?> GetByIdAsync(int id)
    {
        var client = await _clientRepository.GetByIdAsync(id);

        if (client == null)
        {
            return null;
        }

        return _mapper.Map<ClientDto>(client);
    }
}