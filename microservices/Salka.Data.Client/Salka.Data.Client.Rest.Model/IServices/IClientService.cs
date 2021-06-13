using Salka.Data.Clients.Model.Data;
using Salka.Data.Clients.Rest.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.Data.Clients.Rest.Model.IServices
{
    public interface IClientService
    {
        Task<List<ClientDto>> GetAllClientsAsync();
        Task<ClientDto> GetClientByIdAsync(int id);
        Task<ClientDto> PostNewClient(ClientDto clientDto);
        Task<List<ClientDto>> GetClientsByNameAsync(string bandname);
        Task<int> GetClientIdByNameAsync(string bandname);
        Task<ClientModel> GetClientModelAsync(string bandName);
    }
}
