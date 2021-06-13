

namespace Salka.WebApp.Client.Model
{
    using Salka.WebApp.Client.Model.Data;
    using Salka.WebApp.Client.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using IdentityModel.Client;
    using System.Net.Http.Headers;
    using Salka.WebApp.Client.Model.Models;

    public class NetworkClient : INetwork
    {
        private readonly ServiceClient serviceClient;
        public NetworkClient(string serviceHost, int servicePort)
        {
            Debug.Assert(condition: !String.IsNullOrEmpty(serviceHost) && servicePort > 0);

            this.serviceClient = new ServiceClient(serviceHost, servicePort);
        }

        public List<Equipment> GetAllEquipment()
        {
            string callUri = String.Format("Equipment");

            List<Equipment> doctors = this.serviceClient.CallWebService<List<Equipment>>(HttpMethod.Get, callUri);

            return doctors;
        }

        public async Task PostNewReservation(ReservationModel reservationModel)
        {
            string callUri = String.Format("Schedule");

            await this.serviceClient.CallWebServiceAsync<ReservationModel>(HttpMethod.Post, callUri, reservationModel);
        }

        public List<ReservationModel> GetAllReservations()
        {
            string callUri = String.Format("Schedule");

            List<ReservationModel> reservations = this.serviceClient.CallWebService<List<ReservationModel>>(HttpMethod.Get, callUri);

            return reservations;
        }
    }
}
