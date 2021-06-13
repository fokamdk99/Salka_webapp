using Ardalis.Specification;
using Salka.Data.Equipments.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.Data.Equipments.Model.Specifications
{
    public class EquipmentSpecification : Specification<Equipment>
    {
        public EquipmentSpecification(int equipmentCategoryId)
        {
            Query.Where(e => e.EquipmentCategoryId == equipmentCategoryId);
        }
    }
}
