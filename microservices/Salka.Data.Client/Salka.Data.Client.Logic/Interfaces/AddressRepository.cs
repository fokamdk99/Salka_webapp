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
    public class AddressRepository : IAddressRepository
    {
        public async Task<Address> GetAddressByAddressIdAsync(int addressId)
        {
            using (var salkadb = new salkadbclientContext())
            {
                var Address = await salkadb.Addresses.Where(a => a.Id == addressId).SingleOrDefaultAsync();
                return Address;
            }
        }

        /*
        public async Task<Address> PostNewAddress(Address address)
        {
            using (var salkadb = new salkadbclientContext())
            {
                var city = await salkadb.Cities.Where(c => c.CityId == address.CityId).SingleAsync();
                address.City = city;
                await salkadb.Addresses.AddAsync(address);
                await salkadb.SaveChangesAsync();
                return address;
            }
        }
        */

        public async Task<Address> InsertNewAddress(Address address)
        {
            using (var salkadb = new salkadbclientContext())
            {
                var addressCount = salkadb.Addresses.Where(a => a.Street == address.Street)
                    .Where(a => a.CityId == address.CityId).Where(a => a.HouseNumber == address.HouseNumber)
                    .Where(a => a.FlatNumber == address.FlatNumber).Where(a => a.PostId == address.PostId).Count();
                if (addressCount == 0)
                {
                    await salkadb.Addresses.AddAsync(address);
                    await salkadb.SaveChangesAsync();
                    return address;
                }
                return await salkadb.Addresses.Where(a => a.Street == address.Street)
                    .Where(a => a.CityId == address.CityId).Where(a => a.HouseNumber == address.HouseNumber)
                    .Where(a => a.FlatNumber == address.FlatNumber).Where(a => a.PostId == address.PostId).SingleAsync();
            }
        }
    }
}
