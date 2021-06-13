using System;
using System.Collections.Generic;

#nullable disable

namespace Salka.Data.Equipments.Model.Data
{
    public partial class EquipmentCategory : BaseEntity
    {
        public EquipmentCategory()
        {
            Equipment = new HashSet<Equipment>();
        }

        public EquipmentCategory(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }

        public string Name { get; set; }

        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
