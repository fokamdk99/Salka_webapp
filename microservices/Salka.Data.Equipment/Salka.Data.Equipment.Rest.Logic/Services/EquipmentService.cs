using Salka.Data.Equipments.Model.Data;
using Salka.Data.Equipments.Model.Extensions;
using Salka.Data.Equipments.Model.Interfaces;
using Salka.Data.Equipments.Model.Specifications;
using Salka.Data.Equipments.Rest.Logic.Mappers;
using Salka.Data.Equipments.Rest.Model.Dtos;
using Salka.Data.Equipments.Rest.Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.Data.Equipments.Rest.Logic.Services
{
    public class EquipmentService : IEquipmentService
    {
        //private readonly IEquipmentRepository equipmentRepository;
        private readonly IAsyncRepository<Equipment> _asyncRepository;
        public EquipmentService(IAsyncRepository<Equipment> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }
        public async Task<List<EquipmentDto>> GetAllEquipmentAsync()
        {
            List<EquipmentDto> EquipmentDtos = new List<EquipmentDto>();
            var Equipment = await _asyncRepository.ListAllAsync();
            foreach (Equipment equipment in Equipment)
            {
                var EquipmentCategory = await _asyncRepository.EquipmentCategoryByEquipmentIdAsync(equipment.Id);
                var EquipmentCategoryDto = EquipmentCategory.MapToEquipmentCategoryDto();
                var equipmentDto = equipment.MapToEquipmentDto();
                equipmentDto.EquipmentCategory = EquipmentCategoryDto;
                EquipmentDtos.Add(equipmentDto);
            }
            return EquipmentDtos;
        }
        public async Task<List<EquipmentDto>> EquipmentByCategoryIdAsync(int categoryId)
        {
            List<EquipmentDto> EquipmentDtos = new List<EquipmentDto>();
            var equipmentSpecification = new EquipmentSpecification(categoryId);
            var Equipment = await _asyncRepository.ListAsync(equipmentSpecification);
            foreach (Equipment equipment in Equipment)
            {
                var EquipmentCategory = await _asyncRepository.EquipmentCategoryByEquipmentIdAsync(equipment.Id);
                var EquipmentCategoryDto = EquipmentCategory.MapToEquipmentCategoryDto();
                var equipmentDto = equipment.MapToEquipmentDto();
                equipmentDto.EquipmentCategory = EquipmentCategoryDto;
                EquipmentDtos.Add(equipmentDto);
            }
            return EquipmentDtos;
        }
    }
}
