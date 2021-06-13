using Salka.Data.Clients.Model.Data;
using Salka.Data.Clients.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Salka.Data.Clients.Logic.Interfaces
{
    public class ClientsRepository : IClientRepository
    {
        public async Task<object> GetAllR(string dbset)
        {
            using (var salkadb = new salkadbclientContext())
            {
                object result;
                switch (dbset)
                {
                    case "Address":
                        result = await salkadb.Addresses.Select(r => r).ToListAsync();
                        break;
                    case "City":
                        result = await salkadb.Cities.Select(r => r).ToListAsync();
                        break;
                    case "Client":
                        result = await salkadb.Clients.Select(r => r).ToListAsync();
                        break;
                    case "Post":
                        result = await salkadb.Posts.Select(r => r).ToListAsync();
                        break;
                    case "RecordingStudio":
                        result = await salkadb.RecordingStudios.Select(r => r).ToListAsync();
                        break;
                    case "Staff":
                        result = await salkadb.Staff.Select(r => r).ToListAsync();
                        break;
                    default:
                        result = null;
                        break;
                }
                return result;
            }
        }

        public async Task<List<Client>> GetAllClientsAsync()
        {
            using (var salkadb = new salkadbclientContext())
            {
                var clients = await salkadb.Clients.ToListAsync();
                return clients;
            }
        }

        public async Task<Client> GetClientById(int id)
        {
            using (var salkadb = new salkadbclientContext())
            {
                var client = await salkadb.Clients.Where(c => c.Id == id).SingleOrDefaultAsync();
                return client;
            }
        }

        public async Task<Client> PostNewClient(Client client)
        {
            using (var salkadb = new salkadbclientContext())
            {
                /*
                try
                {
                    var recordingStudio = await salkadb.RecordingStudios.Where(rs => rs.RecordingStudioId == client.RecordingStudioId).SingleAsync();
                    client.RecordingStudio = recordingStudio;
                }
                catch(Exception e)
                {
                    Console.WriteLine("RecordingStudioId invalid");
                    return null;
                }
                try
                {
                    var address = await salkadb.Addresses.Where(a => a.AddressId == client.AddressId).SingleAsync();
                    client.Address = address;
                }
                catch(Exception e)
                {
                    Console.WriteLine("AddressId invalid");
                    return null;
                }

                */

                salkadb.Clients.Add(client);
                await salkadb.SaveChangesAsync();
                return client;
            }
        }

        public async Task<Client> ModifyClientAsync(Client client, Address address, City city, Post post, RecordingStudio recordingStudio)
        {
            using (var salkadb = new salkadbclientContext())
            {
                var Client = await salkadb.Clients.Where(c => c.Id == client.Id).SingleAsync();
                address.City = city;
                address.Post = post;
                Client.Address = address;
                Client.RecordingStudio = recordingStudio;
                await salkadb.SaveChangesAsync();
                return Client;
            }
        }
    }
}
