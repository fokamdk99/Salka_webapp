using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.WebApp.Client.Model.Data
{
    public class Resource
    {
        public int ResourceId { get; set; }
        public int Quantity { get; set; }
        public int EquipmentId { get; set; }
        public int ReservationId { get; set; }
        public Resource()
        {

        }

        public Resource(int quantity, int equipmentId, int reservationId) : this()
        {
            Quantity = quantity;
            EquipmentId = equipmentId;
            ReservationId = reservationId;
        }

        public Resource(int resourceId, int quantity, int equipmentId, int reservationId) : this(quantity, equipmentId, reservationId)
        {
            ResourceId = resourceId;
        }
    }
}
