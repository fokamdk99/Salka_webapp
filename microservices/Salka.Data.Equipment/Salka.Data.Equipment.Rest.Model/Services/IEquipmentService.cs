using Salka.Data.Equipments.Rest.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.Data.Equipments.Rest.Model.Services
{
    public interface IEquipmentService
    {
        Task<List<EquipmentDto>> GetAllEquipmentAsync();
        Task<List<EquipmentDto>> EquipmentByCategoryIdAsync(int categoryId);
    }
}
