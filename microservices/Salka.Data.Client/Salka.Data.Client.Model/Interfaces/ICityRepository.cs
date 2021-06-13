using Salka.Data.Clients.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.Data.Clients.Model.Interfaces
{
    public interface ICityRepository
    {
        Task<City> PostNewCity(City city);
        Task<City> GetCityByCityIdAsync(int cityId);
    }
}
