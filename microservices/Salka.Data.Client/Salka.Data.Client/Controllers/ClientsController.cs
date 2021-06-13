using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Salka.Data.Clients.Model.Data;
using Salka.Data.Clients.Rest.Model.Dtos;
using Salka.Data.Clients.Rest.Model.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Salka.Data.Clients.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService clientService;
        public ClientsController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        [HttpGet]
        [Route("get")]
        public async Task<List<ClientDto>> GetAllClientsAsync()
        {
            return await clientService.GetAllClientsAsync();
        }

        [HttpGet]
        [Route("get/{clientId}/")]
        public async Task<ClientDto> GetClientByIdAsync(int clientId)
        {
            return await clientService.GetClientByIdAsync(clientId);
        }

        [HttpGet]
        public async Task<ClientModel> GetClientModelAsync()
        {
            string bandName = Request.Headers["bandname"];
            //var userClaim = User.FindFirst("bandname");
            //var bandname = userClaim.Value; //TO DO: nie przesylane sa zadne claimy!
            return await clientService.GetClientModelAsync("Najarani"); //TO DO: zamien bandname
        }

        [HttpGet] //comment
        [Route("get/client/{clientName}/")]
        public async Task<List<ClientDto>> GetClientByIdAsync(string clientName)
        {
            return await clientService.GetClientsByNameAsync(clientName);
        }

        [HttpGet]
        [Route("get/clientid/{clientName}/")]
        public async Task<int> GetClientIdByNameAsync(string clientName)
        {
            return await clientService.GetClientIdByNameAsync(clientName);
        }


        [HttpPost]
        [Route("post/postnewclient")]
        public async Task<ClientDto> PostNewClient(ClientDto clientDto)
        {
            return await clientService.PostNewClient(clientDto);
        }
    }
}