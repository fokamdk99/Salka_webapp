using System;
using System.Collections.Generic;

#nullable disable

namespace Salka.Data.Equipments.Model.Data2
{
    public partial class Equipmentcategory
    {
        public Equipmentcategory()
        {
            Equipment = new HashSet<Equipment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
