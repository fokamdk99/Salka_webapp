using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Salka.Data.Equipments.Rest.Model.Dtos;
using Salka.Data.Equipments.Rest.Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salka.Data.Equipment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService equipmentService;
        public EquipmentController(IEquipmentService equipmentService)
        {
            this.equipmentService = equipmentService;
        }
        
        [HttpGet]
        public async Task<List<EquipmentDto>> GetAllEquipmentAsync()
        {
            return await equipmentService.GetAllEquipmentAsync();
        }

        [HttpGet]
        [Route("{categoryId}/")]
        public async Task<List<EquipmentDto>> EquipmentByCategoryIdAsync(int categoryId)
        {
            return await equipmentService.EquipmentByCategoryIdAsync(categoryId);
        }
    }
}
