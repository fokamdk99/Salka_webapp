using System;
using System.Collections.Generic;

#nullable disable

namespace Salka.Data.Clients.Model.Data
{
    public partial class City : BaseEntity
    {
        public City()
        {
            Addresses = new HashSet<Address>();
        }

        //public int CityId { get; set; }
        public string Name { get; set; }

        public City(string name) : this()
        {
            Name = name;
        }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
