using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.Data.Clients.Rest.Model.Dtos
{
    public class CityDto
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public CityDto()
        {

        }

        public CityDto(string name) : this()
        {
            Name = name;
        }

        public CityDto(int cityId, string name) : this(name)
        {
            CityId = cityId;
        }
    }
}
