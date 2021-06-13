using Microsoft.EntityFrameworkCore;
using Salka.Data.Clients.Model.Data;
using Salka.Data.Clients.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.Data.Clients.Logic.Interfaces
{
    public class CityRepository : ICityRepository
    {
        public async Task<City> GetCityByCityIdAsync(int cityId)
        {
            using (var salkadb = new salkadbclientContext())
            {
                var city = await salkadb.Cities.Where(c => c.Id == cityId).SingleAsync();
                return city;
            }
        }
        public async Task<City> PostNewCity(City city)
        {
            using (var salkadb = new salkadbclientContext())
            {
                var cityCount = salkadb.Cities.Where(c => c.Name == city.Name).Count();
                if (cityCount == 0)
                {
                    await salkadb.Cities.AddAsync(city);
                    await salkadb.SaveChangesAsync();
                    return city;
                }
                
                return await salkadb.Cities.Where(c => c.Name == city.Name).SingleAsync();
            }
        }
    }
}
