

namespace Salka.WebApp.Client.Model
{
    using Salka.WebApp.Client.Model.Data;
    using Salka.WebApp.Client.Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public partial class Model : IData
    {
        //public List<JsonDoctor> DoctorList
        public List<Equipment> EquipmentList
        {
            get { return this.equipmentList; }
            private set
            {
                this.equipmentList = value;
                this.RaisePropertyChanged("DoctorList");
            }
        }

        private List<Equipment> equipmentList = new List<Equipment>();

        public List<ReservationModel> ReservationList
        {
            get { return this.reservationList; }
            private set
            {
                this.reservationList = value;
                this.RaisePropertyChanged("ReservationList");
            }
        }

        private List<ReservationModel> reservationList = new List<ReservationModel>();
    }
}
