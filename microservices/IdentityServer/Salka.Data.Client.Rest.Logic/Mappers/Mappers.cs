using Salka.Data.Clients.Model.Data;
using Salka.Data.Clients.Rest.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.Data.Clients.Rest.Logic.Mappers
{
    public static class Mappers
    {
        public static ClientDto MapToGetClientDto(this Client client)
        {
            if (client == null)
            {
                return null;
            }

            return new ClientDto(client.Id, client.Bandname, client.PhoneNumber, client.Email,
                client.RecordingStudio.MapToRecordingStudioDto(), client.Address.MapToGetAddressDto());
        }

        public static Client MapToClient(this ClientDto clientDto)
        {
            if (clientDto == null)
            {
                return null;
            }

            return new Client(clientDto.Bandname, clientDto.PhoneNumber, clientDto.Email,
                clientDto.RecordingStudio.RecordingStudioId, clientDto.Address.AddressId);
        }

        public static CityDto MapToCityDto(this City city)
        {
            if (city == null)
            {
                return null;
            }

            return new CityDto(city.Id, city.Name);
        }

        public static City MapToCity(this CityDto cityDto)
        {
            if (cityDto == null)
            {
                return null;
            }

            return new City(cityDto.Name);
        }

        public static PostDto MapToPostDto(this Post post)
        {
            if (post == null)
            {
                return null;
            }

            return new PostDto(post.Id, post.PostalCode);
        }

        public static Post MapToPost(this PostDto postDto)
        {
            if (postDto == null)
            {
                return null;
            }

            return new Post(postDto.PostId, postDto.PostalCode);
        }

        public static AddressDto MapToGetAddressDto(this Address address)
        {
            if (address == null)
            {
                return null;
            }

            return new AddressDto(address.Id, address.Street, address.City.MapToCityDto(), 
                address.HouseNumber, address.FlatNumber, address.Post.MapToPostDto());
        }

        public static Address MapToAddress(this AddressDto addressDto)
        {
            if (addressDto == null)
            {
                return null;
            }

            return new Address(addressDto.Street, addressDto.City.CityId,
                addressDto.HouseNumber, addressDto.FlatNumber, addressDto.PostDto.PostId);
        }

        public static RecordingStudioDto MapToRecordingStudioDto(this RecordingStudio recordingStudio)
        {
            if (recordingStudio == null)
            {
                return null;
            }

            return new RecordingStudioDto(recordingStudio.Id, recordingStudio.Name, 
                recordingStudio.Address.MapToGetAddressDto());
        }

        public static RecordingStudio MapToRecordingStudio(this RecordingStudioDto recordingStudioDto)
        {
            if (recordingStudioDto == null)
            {
                return null;
            }

            return new RecordingStudio(recordingStudioDto.Name,
                recordingStudioDto.Address.AddressId);
        }
    }
}