using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.WebApp.Client.Model.Data
{
    public class Equipment
    {
        public int EquipmentId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public float Cost { get; set; }
        public EquipmentCategory EquipmentCategory { get; set; }

        public Equipment()
        {

        }

        public Equipment(string name, int quantity, float cost) : this()
        {
            Name = name;
            Quantity = quantity;
            Cost = cost;
        }

        public Equipment(int equipmentId, string name, int quantity, float cost) : this(name, quantity, cost)
        {
            EquipmentId = equipmentId;
        }

        public Equipment(int equipmentId, string name, int quantity, float cost, EquipmentCategory equipmentCategory) : this(equipmentId, name, quantity, cost)
        {
            EquipmentCategory = equipmentCategory;
        }
    }
}
