using Salka.Data.Equipments.Model.Data;
using Salka.Data.Equipments.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Salka.Data.Equipments.Logic.Interfaces
{
    public class EquipmentRepository : IEquipmentRepository
    {
        public async Task<List<Equipment>> GetAllEquipmentAsync()
        {
            using (var salkadb = new salkadbequipmentContext())
            {
                var equipment = await salkadb.Equipments.Select(e => e).ToListAsync();
                return equipment;
            }
        }

        public async Task<List<Equipment>> EquipmentByCategoryIdAsync(int categoryId)
        {
            using (var salkadb = new salkadbequipmentContext())
            {
                var equipment = await salkadb.Equipments.Where(e => e.EquipmentCategoryId == categoryId).ToListAsync();
                return equipment;
            }
        }

        public async Task<EquipmentCategory> EquipmentCategoryByEquipmentIdAsync(int equipmentId)
        {
            using (var salkadb = new salkadbequipmentContext())
            {
                var equipmentCategory = await salkadb.Equipments.Where(e => e.Id == equipmentId).Select(e => e.EquipmentCategory).SingleOrDefaultAsync();
                return equipmentCategory;
            }
        }
    }
}
