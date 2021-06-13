using Salka.Data.Clients.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.Data.Clients.Rest.Model.Dtos
{
    public class ClientDto
    {
        public int ClientId { get; set; }
        public string Bandname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public RecordingStudioDto RecordingStudio { get; set; }
        public AddressDto Address { get; set; }

        public ClientDto()
        {

        }

        public ClientDto(string bandname, string phoneNumber, string email) : this()
        {
            Bandname = bandname;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public ClientDto(int clientId, string bandname, string phoneNumber, string email) : this(bandname, phoneNumber, email)
        {
            ClientId = clientId;
        }

        public ClientDto(int clientId, string bandname, string phoneNumber, string email, RecordingStudioDto recordingStudio, AddressDto address) : this(clientId, bandname, phoneNumber, email)
        {
            RecordingStudio = recordingStudio;
            Address = address;
        }
    }
}
