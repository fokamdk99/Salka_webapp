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
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;
        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }
        [HttpGet]
        public async Task<List<EquipmentDto>> GetAllEquipmentAsync()
        {
            return await _equipmentService.GetAllEquipmentAsync();
        }
    }
}
