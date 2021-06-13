using System;
using System.Collections.Generic;
using System.Text;

namespace Salka.WebApp.Client.Model.Models
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
    }
}
