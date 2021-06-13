using Salka.Data.Clients.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.Data.Clients.Rest.Model.Dtos
{
    public class AddressDto
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public CityDto City { get; set; }
        public int? HouseNumber { get; set; }
        public int? FlatNumber { get; set; }
        public PostDto PostDto { get; set; }

        public AddressDto()
        {

        }

        public AddressDto(string street, CityDto city, int? flatNumber, PostDto postDto) : this()
        {
            Street = street;
            City = city;
            FlatNumber = FlatNumber;
            PostDto = postDto;
        }

        public AddressDto(int addressId, string street, CityDto city, int? flatNumber, PostDto postDto) : this(street, city, flatNumber, postDto)
        {
            AddressId = addressId;
        }

        public AddressDto(int addressId, string street, CityDto city, int? houseNumber, int? flatNumber, PostDto postDto) : this(addressId, street, city, flatNumber, postDto)
        {
            HouseNumber = houseNumber;
        }
    }
}
