using System;
using System.Collections.Generic;

#nullable disable

namespace Salka.Data.Clients.Model.Data
{
    public partial class Address : BaseEntity
    {
        public Address()
        {
            Clients = new HashSet<Client>();
            RecordingStudios = new HashSet<RecordingStudio>();
            Staff = new HashSet<Staff>();
        }

        //public int AddressId { get; set; }
        public string Street { get; set; }
        public int CityId { get; set; }
        public int? HouseNumber { get; set; }
        public int? FlatNumber { get; set; }
        public int PostId { get; set; }

        public Address(string street, int cityId, int? houseNumber, int? flatNumber, int postId) : this()
        {
            Street = street;
            CityId = cityId;
            HouseNumber = houseNumber;
            FlatNumber = flatNumber;
            PostId = postId;
        }

        public Address(int addressId, string street, int cityId, int? houseNumber, int? flatNumber, int postId) : this(street, cityId, houseNumber, flatNumber, postId)
        {
            Id = addressId;
        }

        public virtual City City { get; set; }
        public virtual Post Post { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<RecordingStudio> RecordingStudios { get; set; }
        public virtual ICollection<Staff> Staff { get; set; }
    }
}
