using System;
using System.Collections.Generic;

#nullable disable

namespace Salka.Data.Equipments.Model.Data
{
    public partial class Equipment : BaseEntity
    {
        public Equipment()
        {
            Resources = new HashSet<Resource>();
        }

        public Equipment(int id, string name, float cost, int equipmentCategoryId) : this()
        {
            Id = id;
            Name = name;
            Cost = cost;
            EquipmentCategoryId = equipmentCategoryId;
        }

        public string Name { get; set; }
        public int Quantity { get; set; }
        public float Cost { get; set; }
        public int EquipmentCategoryId { get; set; }

        public virtual EquipmentCategory EquipmentCategory { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
    }
}
