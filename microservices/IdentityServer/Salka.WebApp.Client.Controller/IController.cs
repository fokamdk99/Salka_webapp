

namespace Salka.WebApp.Client.Controller
{
    using Salka.WebApp.Client.Model;
    using Salka.WebApp.Client.Model.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    public interface IController : INotifyPropertyChanged
    {
        IModel Model { get; }
        Task GetAllEquipmentAsync();
        Task PostNewReservationAsync(ReservationModel reservationModel);
    }
}
