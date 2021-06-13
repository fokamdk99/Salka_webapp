using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.Data.Equipments.Rest.Model.Dtos
{
    public class EquipmentCategoryDto
    {
        public int EquipmentCategoryId { get; set; }
        public string Name { get; set; }
        public EquipmentCategoryDto()
        {

        }
        public EquipmentCategoryDto(string name) : this()
        {
            Name = name;
        }
        public EquipmentCategoryDto(int equipmentCategoryId, string name) : this(name)
        {
            EquipmentCategoryId = equipmentCategoryId;
            
        }
    }
}
