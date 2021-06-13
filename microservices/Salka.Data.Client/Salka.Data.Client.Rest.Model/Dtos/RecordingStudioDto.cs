using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.Data.Clients.Rest.Model.Dtos
{
    public class RecordingStudioDto
    {
        public int RecordingStudioId { get; set; }
        public string Name { get; set; }
        public AddressDto Address { get; set; }

        public RecordingStudioDto()
        {

        }

        public RecordingStudioDto(string name, AddressDto address) : this()
        {
            Name = name;
            Address = address;
        }

        public RecordingStudioDto(int recordingStudioId, string name, AddressDto address) : this(name, address)
        {
            RecordingStudioId = recordingStudioId;
        }
    }
}
