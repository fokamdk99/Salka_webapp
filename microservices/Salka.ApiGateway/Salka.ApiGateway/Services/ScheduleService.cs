using Salka.ApiGateway.Config;
using Salka.ApiGateway.Infrastructure;
using Salka.ApiGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Salka.ApiGateway.Services
{
    public class ScheduleService : IScheduleService
    {
        IHttpClientFactory _clientFactory;
        public ScheduleService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<List<ReservationModel>> GetAllReservations()
        {
            var urls = new UrlsConfig();
            var url = urls.scheduleOperations.GetAllReservations();
            var handler = new HttpClientAuthorizationDelegatingHandler(_clientFactory);
            var response = await handler.CallWebServiceAsync<List<ReservationModel>>(HttpMethod.Get, url);
            return response;
        }

        public async Task PostNewReservationAsync(ReservationModelDto reservationModelDto)
        {
            var urls = new UrlsConfig();
            var url = urls.scheduleOperations.PostNewReservation();
            var handler = new HttpClientAuthorizationDelegatingHandler(_clientFactory);
            await handler.PostWebServiceAsync<ReservationModelDto>(HttpMethod.Post, url, reservationModelDto);
        }

        public async Task<List<ReservationModel>> GetReservationsByDateScope()
        {
            var urls = new UrlsConfig();
            var url = urls.scheduleOperations.GetReservationsByDateScope();
            var handler = new HttpClientAuthorizationDelegatingHandler(_clientFactory);
            var response = await handler.CallWebServiceAsync<List<ReservationModel>>(HttpMethod.Get, url);
            return response;
        }
    }
}
