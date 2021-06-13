

namespace Salka.WebApp.Client.Model
{
    using Salka.WebApp.Client.Model.Data;
    using Salka.WebApp.Client.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Salka.WebApp.Client.Model.Models;

    public partial class Model : IOperations
    {
        public void LoadEquipmentList()
        {
            this.LoadEquipmentTask();
        }

        public void LoadReservationList()
        {
            this.LoadReservationTask();
        }

        private void LoadEquipmentTask()
        {
            INetwork networkClient = NetworkClientFactory.GetNetworkClient("localhost", 6001);

            try
            {
                List<Equipment> doctors = networkClient.GetAllEquipment();
                this.EquipmentList = doctors;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void LoadReservationTask()
        {
            INetwork networkClient = NetworkClientFactory.GetNetworkClient("localhost", 7001);

            try
            {
                List<ReservationModel> reservations = networkClient.GetAllReservations();
                this.ReservationList = reservations;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
