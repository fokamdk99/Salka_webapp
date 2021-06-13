using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salka.ApiGateway.Models
{
    public class ClientModel
    {
        public string Bandname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public int CityId { get; set; }
        public int? HouseNumber { get; set; }
        public int? FlatNumber { get; set; }
        public string PostalCode { get; set; }
    }
}
