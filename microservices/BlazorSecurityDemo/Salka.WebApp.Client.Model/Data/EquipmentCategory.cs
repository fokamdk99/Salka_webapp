using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.WebApp.Client.Model.Data
{
    public class EquipmentCategory
    {
        public int EquipmentCategoryId { get; set; }
        public string Name { get; set; }
        public EquipmentCategory()
        {

        }
        public EquipmentCategory(string name) : this()
        {
            Name = name;
        }
        public EquipmentCategory(int equipmentCategoryId, string name) : this(name)
        {
            EquipmentCategoryId = equipmentCategoryId;

        }
    }
}
