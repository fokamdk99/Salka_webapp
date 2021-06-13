using System;
using System.Collections.Generic;

#nullable disable

namespace Salka.Data.Clients.Model.Data
{
    public partial class Client : BaseEntity
    {
        //public int ClientId { get; set; }
        public string Bandname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int RecordingStudioId { get; set; }
        public int AddressId { get; set; }
        public Client()
        {

        }

        public Client(string bandname, string phoneNumber, string email, int recordingStudioId, int addressId) : this()
        {
            Bandname = bandname;
            PhoneNumber = phoneNumber;
            Email = email;
            RecordingStudioId = recordingStudioId;
            AddressId = addressId;
        }

        public virtual Address Address { get; set; }
        public virtual RecordingStudio RecordingStudio { get; set; }
    }
}
