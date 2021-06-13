

namespace Salka.WebApp.Client.Model
{
    using Salka.WebApp.Client.Model.Data;
    using Salka.WebApp.Client.Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface INetwork
    {
        List<Equipment> GetAllEquipment();
        List<ReservationModel> GetAllReservations();
        Task PostNewReservation(ReservationModel reservationModel);
    }
}
