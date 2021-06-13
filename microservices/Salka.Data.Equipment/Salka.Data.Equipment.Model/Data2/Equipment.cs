using System;
using System.Collections.Generic;

#nullable disable

namespace Salka.Data.Equipments.Model.Data2
{
    public partial class Equipment
    {
        public Equipment()
        {
            Resources = new HashSet<Resource>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public float Cost { get; set; }
        public int EquipmentCategoryId { get; set; }

        public virtual Equipmentcategory EquipmentCategory { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
    }
}
