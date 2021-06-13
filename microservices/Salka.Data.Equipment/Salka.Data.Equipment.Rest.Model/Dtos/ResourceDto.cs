using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.Data.Equipments.Rest.Model.Dtos
{
    public class ResourceDto
    {
        public int ResourceId { get; set; }
        public int Quantity { get; set; }
        public int EquipmentId { get; set; }
        public int ReservationId { get; set; }
        public ResourceDto()
        {

        }

        public ResourceDto(int quantity, int equipmentId, int reservationId) : this()
        {
            Quantity = quantity;
            EquipmentId = equipmentId;
            ReservationId = reservationId;
        }

        public ResourceDto(int resourceId, int quantity, int equipmentId, int reservationId) : this(quantity, equipmentId, reservationId)
        {
            ResourceId = resourceId;
        }
    }
}
