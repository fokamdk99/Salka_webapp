using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Salka.ApiGateway.Models;
using Salka.ApiGateway.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salka.ApiGateway.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task<ClientModel> GetClientDataAsync()
        {
            var client = await _clientService.GetClientDataAsync(User.FindFirst("bandname").Value);
            return client;
        }
    }
}
