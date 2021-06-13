using System;
using System.Collections.Generic;

#nullable disable

namespace Salka.Data.Equipments.Model.Data
{
    public partial class Resource : BaseEntity
    {
        public int Quantity { get; set; }
        public int EquipmentId { get; set; }
        public int ReservationId { get; set; }

        public Resource()
        {

        }

        public Resource(int id, int quantity, int equipmentId, int reservationId) : this()
        {
            Id = id;
            Quantity = quantity;
            EquipmentId = equipmentId;
            ReservationId = reservationId;
        }
        public virtual Equipment Equipment { get; set; }
    }
}
