using Salka.Data.Equipments.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.Data.Equipments.Model.Interfaces
{
    public interface IEquipmentRepository
    {
        Task<List<Equipment>> GetAllEquipmentAsync();
        Task<List<Equipment>> EquipmentByCategoryIdAsync(int categoryId);
        Task<EquipmentCategory> EquipmentCategoryByEquipmentIdAsync(int equipmentId);
    }
}
