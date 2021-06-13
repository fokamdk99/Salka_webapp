using Salka.Data.Clients.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.Data.Clients.Model.Interfaces
{
    public interface IClientRepository
    {
        Task<dynamic> GetAllR(string dbset);
        Task<List<Client>> GetAllClientsAsync();
        Task<Client> GetClientById(int id);
        Task<Client> PostNewClient(Client client);
        Task<Client> ModifyClientAsync(Client client, Address address, City city, Post post, RecordingStudio recordingStudio);
    }
}
