using Salka.Data.Schedules.Model.Data;
using Salka.Data.Schedules.Model.Extensions;
using Salka.Data.Schedules.Model.Interfaces;
using Salka.Data.Schedules.Model.Specifications;
using Salka.Data.Schedules.Rest.Logic.Mappers;
using Salka.Data.Schedules.Rest.Model.Dtos;
using Salka.Data.Schedules.Rest.Model.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.Data.Schedules.Rest.Logic.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IAsyncRepository<Reservation> _asyncRepository;
        private readonly IAsyncRepository<ReservationDate> _asyncDateRepository;
        private readonly IAsyncRepository<ReservationType> _asyncTypeRepository;
        public ScheduleService(IAsyncRepository<Reservation> asyncRepository, IAsyncRepository<ReservationDate> asyncDateRepository, IAsyncRepository<ReservationType> asyncTypeRepository)
        {
            _asyncRepository = asyncRepository;
            _asyncDateRepository = asyncDateRepository;
            _asyncTypeRepository = asyncTypeRepository;
        }
        public async Task<List<ReservationDto>> GetAllReservationsInSchedule()
        {
            List<ReservationDto> reservationDtos = new List<ReservationDto>();
            var reservations = await _asyncRepository.ListAllAsync();
            foreach(Reservation reservation in reservations)
            {
                reservation.ReservationType = await _asyncRepository.ReservationTypeByReservationId(reservation.ReservationTypeId);
                reservation.ReservationDates.Add(await _asyncRepository.ReservationDateByReservationId(reservation.Id));
                var reservationDto = reservation.MapToReservationDto();

                reservationDtos.Add(reservationDto);
            }

            return reservationDtos;
        }

        public async Task PostNewReservationAsync(ReservationModelDto reservationModelDto)
        {
            ReservationDate reservationDate = new ReservationDate(reservationModelDto.Date, reservationModelDto.Start, reservationModelDto.End);
            Reservation reservation = new Reservation(0, 0, reservationModelDto.IsRegular, 10, reservationModelDto.Comment, reservationModelDto.NumberOfVocals);

            await _asyncRepository.PostNewReservationAsync(reservationDate, reservation, reservationModelDto.ReservationType);
        }

        public async Task<ReservationDateDto> GetReservationDateByReservationId(ReservationDto reservationDto)
        {
            var reservationDateSpecification = new ReservationDateSpecification(reservationDto.Id);
            var reservationDate = await _asyncDateRepository.SingleAsync(reservationDateSpecification);
            return reservationDate.MapToReservationDateDto();

        }

        public async Task<ReservationTypeDto> GetReservationTypeByReservationId(ReservationDto reservationDto)
        {
            var reservationTypeSpecification = new ReservationTypeSpecification(reservationDto.ReservationTypeId);
            var reservationType = await _asyncTypeRepository.SingleAsync(reservationTypeSpecification);
            return reservationType.MapToReservationTypeDto();

        }

        public async Task<List<ReservationModelDto>> GetReservationModels()
        {
            List<ReservationModelDto> reservationModels = new List<ReservationModelDto>();
            
            var reservations = await _asyncRepository.ListAllAsync();
            foreach(Reservation reservation in reservations)
            {
                var reservationDto = reservation.MapToReservationDto();
                var reservationDateDto = await this.GetReservationDateByReservationId(reservationDto);
                var reservationTypeDto = await this.GetReservationTypeByReservationId(reservationDto);
                
                var reservationModel = new ReservationModelDto(reservationDateDto.Date, reservationDateDto.Start, reservationDateDto.End, reservationDto.IsRegular
                    , reservationDto.Comment, reservationDto.NumberOfVocals, reservationTypeDto.Type);
                reservationModels.Add(reservationModel);
            }

            return reservationModels;
        }

        public async Task<List<ReservationModelDto>> GetReservationsByDateScope(DateTime start, DateTime end)
        {
            List<ReservationModelDto> reservationModels = new List<ReservationModelDto>();

            var reservations = await _asyncRepository.GetReservationsByDateScope(start, end);
            foreach (Reservation reservation in reservations)
            {
                var reservationDto = reservation.MapToReservationDto();
                var reservationDateDto = await this.GetReservationDateByReservationId(reservationDto);
                var reservationTypeDto = await this.GetReservationTypeByReservationId(reservationDto);

                var reservationModel = new ReservationModelDto(reservationDateDto.Date, reservationDateDto.Start, reservationDateDto.End, reservationDto.IsRegular
                    , reservationDto.Comment, reservationDto.NumberOfVocals, reservationTypeDto.Type);
                reservationModels.Add(reservationModel);
            }

            return reservationModels;
        }
    }
}
