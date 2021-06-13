using Salka.Data.Equipments.Model.Data;
using Salka.Data.Equipments.Rest.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.Data.Equipments.Rest.Logic.Mappers
{
    public static class Mappers
    {
        public static EquipmentDto MapToEquipmentDto(this Equipment equipment)
        {
            if (equipment == null)
            {
                return null;
            }

            return new EquipmentDto(equipment.Id, equipment.Name, equipment.Quantity, 
                equipment.Cost, equipment.EquipmentCategory.MapToEquipmentCategoryDto());
        }

        public static Equipment MapToEquipment(this EquipmentDto equipmentDto)
        {
            if (equipmentDto == null)
            {
                return null;
            }

            return new Equipment(equipmentDto.EquipmentId, equipmentDto.Name, equipmentDto.Cost, equipmentDto.EquipmentCategory.EquipmentCategoryId);
        }

        public static EquipmentCategoryDto MapToEquipmentCategoryDto(this EquipmentCategory equipmentCategory)
        {
            if (equipmentCategory == null)
            {
                return null;
            }

            return new EquipmentCategoryDto(equipmentCategory.Id, equipmentCategory.Name);
        }

        public static EquipmentCategory MapToEquipmentCategory(this EquipmentCategoryDto equipmentCategoryDto)
        {
            if (equipmentCategoryDto == null)
            {
                return null;
            }

            return new EquipmentCategory(equipmentCategoryDto.EquipmentCategoryId, equipmentCategoryDto.Name);
        }

        public static ResourceDto MapToResourceDto(this Resource resource)
        {
            if (resource == null)
            {
                return null;
            }

            return new ResourceDto(resource.Id, resource.Quantity, resource.EquipmentId, resource.ReservationId);
        }

        public static Resource MapToResource(this ResourceDto resourceDto)
        {
            if (resourceDto == null)
            {
                return null;
            }

            return new Resource(resourceDto.ResourceId, resourceDto.Quantity, resourceDto.EquipmentId, resourceDto.ReservationId);
        }
    }
}
