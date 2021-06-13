using Salka.Data.Equipments.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.Data.Equipments.Rest.Model.Dtos
{
    public class EquipmentDto
    {
        public int EquipmentId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public float Cost { get; set; }
        public EquipmentCategoryDto EquipmentCategory { get; set; }

        public EquipmentDto()
        {

        }

        public EquipmentDto(string name, int quantity, float cost) : this()
        {
            Name = name;
            Quantity = quantity;
            Cost = cost;
        }

        public EquipmentDto(int equipmentId, string name, int quantity, float cost) : this(name, quantity, cost)
        {
            EquipmentId = equipmentId;
        }

        public EquipmentDto(int equipmentId, string name, int quantity, float cost, EquipmentCategoryDto equipmentCategory) : this(equipmentId, name, quantity, cost)
        {
            EquipmentCategory = equipmentCategory;
        }
    }
}
