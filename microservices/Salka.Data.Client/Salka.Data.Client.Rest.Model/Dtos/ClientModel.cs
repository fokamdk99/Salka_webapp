using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.Data.Clients.Rest.Model.Dtos
{
    public class ClientModel
    {
        public string Bandname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string CityName { get; set; }
        public int? HouseNumber { get; set; }
        public int? FlatNumber { get; set; }
        public string PostalCode { get; set; }

        public ClientModel()
        {

        }

        public ClientModel(string bandName, string phoneNumber, string email, string street, string cityName, int? houseNumber, int? flatNumber, string postalCode) : this()
        {
            Bandname = bandName;
            PhoneNumber = phoneNumber;
            Email = email;
            Street = street;
            CityName = cityName;
            HouseNumber = houseNumber;
            FlatNumber = flatNumber;
            PostalCode = postalCode;
        }
    }
}
