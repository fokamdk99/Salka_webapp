using Salka.Data.Clients.Model.Data;
using Salka.Data.Clients.Model.Extensions;
using Salka.Data.Clients.Model.Interfaces;
using Salka.Data.Clients.Model.Specifications;
using Salka.Data.Clients.Rest.Logic.Mappers;
using Salka.Data.Clients.Rest.Model.Dtos;
using Salka.Data.Clients.Rest.Model.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.Data.Clients.Rest.Logic.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository clientRepository;
        //private readonly IRecordingStudioRepository recordingStudioRepository;
        private readonly IAsyncRepository<RecordingStudio> recordingStudioRepository;
        private readonly IAddressRepository addressRepository;
        private readonly ICityRepository cityRepository;
        private readonly IPostRepository postRepository;
        //private readonly IAsyncRepository<Post> postRepository;
        private readonly IAsyncRepository<Client> asyncClientRepository;
        //public ClientService(IClientRepository clientRepository, IRecordingStudioRepository recordingStudioRepository, IAddressRepository addressRepository, ICityRepository cityRepository, IPostRepository postRepository, IAsyncRepository<Client> asyncRepository)
        public ClientService(IClientRepository clientRepository, IAsyncRepository<RecordingStudio> recordingStudioRepository, IAddressRepository addressRepository, ICityRepository cityRepository, IPostRepository postRepository, IAsyncRepository<Client> asyncRepository)
        {
            this.clientRepository = clientRepository;
            this.recordingStudioRepository = recordingStudioRepository;
            this.addressRepository = addressRepository;
            this.cityRepository = cityRepository;
            this.postRepository = postRepository;
            this.asyncClientRepository = asyncRepository;
        }
        public async Task<List<ClientDto>> GetAllClientsAsync()
        {

            //var clients =  await clientRepository.GetAllClientsAsync();
            var clients = await asyncClientRepository.ListAllAsync();
            List<ClientDto> clientdtos = new List<ClientDto>();
            foreach(Client client in clients)
            {
                clientdtos.Add(client.MapToGetClientDto());
            }
            return clientdtos;
            
            

            //return await clientRepository.GetAllR("Client") as List<Client>;
        }

        public async Task<ClientDto> GetClientByIdAsync(int clientId)
        {
            var recordingStudio = await recordingStudioRepository.GetRecordingStudioByClientIdAsync(clientId);
            recordingStudio.Address = await addressRepository.GetAddressByAddressIdAsync(recordingStudio.AddressId);
            recordingStudio.Address.City = await cityRepository.GetCityByCityIdAsync(recordingStudio.Address.CityId);
            recordingStudio.Address.Post = await postRepository.GetPostByPostIdAsync(recordingStudio.Address.PostId);

            //var clientSpecification = new ClientSpecification(clientId);
            var client = await asyncClientRepository.GetByIdAsync(clientId);
            //var client = await clientRepository.GetClientById(clientId);
            client.Address = await addressRepository.GetAddressByAddressIdAsync(client.AddressId);
            client.Address.City = await cityRepository.GetCityByCityIdAsync(client.Address.CityId);
            client.Address.Post = await postRepository.GetPostByPostIdAsync(client.Address.PostId);

            client.RecordingStudio = recordingStudio;

            return client.MapToGetClientDto();
        }

        public async Task<List<ClientDto>> GetClientsByNameAsync(string bandname)
        {
            var clientSpecification = new ClientSpecification(bandname);
            var clients = await asyncClientRepository.ListAsync(clientSpecification);

            List<ClientDto> clientDtos = new List<ClientDto>();
            foreach(Client client in clients)
            {
                var recordingStudio = await recordingStudioRepository.GetRecordingStudioByClientIdAsync(client.RecordingStudioId);
                recordingStudio.Address = await addressRepository.GetAddressByAddressIdAsync(recordingStudio.AddressId);
                recordingStudio.Address.City = await cityRepository.GetCityByCityIdAsync(recordingStudio.Address.CityId);
                recordingStudio.Address.Post = await postRepository.GetPostByPostIdAsync(recordingStudio.Address.PostId);
                client.Address = await addressRepository.GetAddressByAddressIdAsync(client.AddressId);
                client.Address.City = await cityRepository.GetCityByCityIdAsync(client.Address.CityId);
                client.Address.Post = await postRepository.GetPostByPostIdAsync(client.Address.PostId);

                client.RecordingStudio = recordingStudio;

                clientDtos.Add(client.MapToGetClientDto());
            }

            

            return clientDtos;
        }

        public async Task<int> GetClientIdByNameAsync(string bandname)
        {
            var clientSpecification = new ClientSpecification(bandname);
            var client = await asyncClientRepository.SingleAsync(clientSpecification);

            var recordingStudio = await recordingStudioRepository.GetRecordingStudioByClientIdAsync(client.RecordingStudioId);
            recordingStudio.Address = await addressRepository.GetAddressByAddressIdAsync(recordingStudio.AddressId);
            recordingStudio.Address.City = await cityRepository.GetCityByCityIdAsync(recordingStudio.Address.CityId);
            recordingStudio.Address.Post = await postRepository.GetPostByPostIdAsync(recordingStudio.Address.PostId);
            client.Address = await addressRepository.GetAddressByAddressIdAsync(client.AddressId);
            client.Address.City = await cityRepository.GetCityByCityIdAsync(client.Address.CityId);
            client.Address.Post = await postRepository.GetPostByPostIdAsync(client.Address.PostId);

            client.RecordingStudio = recordingStudio;

            return client.MapToGetClientDto().ClientId;
        }


        public async Task<ClientDto> PostNewClient(ClientDto clientDto)
        {
            var city = await cityRepository.PostNewCity(clientDto.Address.City.MapToCity());
            var post = await postRepository.InsertNewPost(clientDto.Address.PostDto.MapToPost());
            var address = clientDto.Address.MapToAddress();
            address.CityId = city.Id;
            address.PostId = post.Id;
            address = await addressRepository.InsertNewAddress(address);
            var recordingStudio = await recordingStudioRepository.GetByIdAsync(clientDto.RecordingStudio.RecordingStudioId);
            var client = clientDto.MapToClient();
            client.RecordingStudioId = recordingStudio.Id;
            client.AddressId = address.Id;
            client = await clientRepository.PostNewClient(client);
            var client2 = await clientRepository.ModifyClientAsync(client, address, city, post, recordingStudio);
            return client2.MapToGetClientDto();
        }

        public async Task<ClientModel> GetClientModelAsync(string bandName)
        {
            var clientId = await this.GetClientIdByNameAsync(bandName);
            var client = await this.GetClientByIdAsync(clientId);
            var clientModel = new ClientModel(client.Bandname, client.PhoneNumber, client.Email, client.Address.Street, 
                client.Address.City.Name, client.Address.HouseNumber, client.Address.FlatNumber, client.Address.PostDto.PostalCode);
            return clientModel;
        }
    }

    
}
