

namespace Salka.WebApp.Client.Controller
{
    using Salka.WebApp.Client.Model;
    using Salka.WebApp.Client.Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public partial class Controller : IController
    {
        public async Task GetAllEquipmentAsync()
        {
            await Task.Run(() => this.GetAllEquipment());
        }

        public async Task PostNewReservationAsync(ReservationModel reservationModel)
        {
            await Task.Run(() => this.PostNewReservation(reservationModel));
        }

        private void GetAllEquipment()
        {
            this.Model.LoadEquipmentList();
        }

        private void PostNewReservation(ReservationModel reservationModel)
        {
            INetwork networkClient = NetworkClientFactory.GetNetworkClient("localhost", 7001);
            try
            {
                networkClient.PostNewReservation(reservationModel);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
