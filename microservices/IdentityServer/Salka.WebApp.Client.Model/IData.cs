

namespace Salka.WebApp.Client.Model
{
    using Salka.WebApp.Client.Model.Data;
    using Salka.WebApp.Client.Model.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface IData : INotifyPropertyChanged
    {
        List<Equipment> EquipmentList { get; }
        List<ReservationModel> ReservationList { get; }
    }
}
