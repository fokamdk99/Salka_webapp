using System;
using System.Collections.Generic;

#nullable disable

namespace Salka.Data.Clients.Model.Data
{
    public partial class RecordingStudio : BaseEntity
    {
        public RecordingStudio()
        {
            Clients = new HashSet<Client>();
            Staff = new HashSet<Staff>();
        }

        //public int RecordingStudioId { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }

        public RecordingStudio(string name, int addressId) : this()
        {
            Name = name;
            AddressId = addressId;
        }

        public virtual Address Address { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Staff> Staff { get; set; }
    }
}
