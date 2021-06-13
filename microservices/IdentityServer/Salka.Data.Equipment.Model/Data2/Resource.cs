using System;
using System.Collections.Generic;

#nullable disable

namespace Salka.Data.Equipments.Model.Data2
{
    public partial class Resource
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int EquipmentId { get; set; }
        public int ReservationId { get; set; }

        public virtual Equipment Equipment { get; set; }
    }
}
