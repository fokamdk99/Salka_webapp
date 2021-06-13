using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salka.ApiGateway.Models
{
    public class EquipmentDto
    {
        public int EquipmentId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public float Cost { get; set; }
        public EquipmentCategoryDto EquipmentCategory { get; set; }
    }
}
