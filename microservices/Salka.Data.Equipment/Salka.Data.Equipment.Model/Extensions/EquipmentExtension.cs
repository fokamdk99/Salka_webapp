using Microsoft.EntityFrameworkCore;
using Salka.Data.Equipments.Model.Data;
using Salka.Data.Equipments.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.Data.Equipments.Model.Extensions
{
    public static class EquipmentExtension
    {
        public static async Task<EquipmentCategory> EquipmentCategoryByEquipmentIdAsync(this IAsyncRepository<Equipment> asyncRepository, int equipmentId)
        {
            using (var salkadb = new salkadbequipmentContext())
            {
                var equipmentCategory = await salkadb.Equipments.Where(e => e.Id == equipmentId).Select(e => e.EquipmentCategory).SingleOrDefaultAsync();
                return equipmentCategory;
            }
        }
    }
}
