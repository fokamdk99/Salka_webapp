using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salka.ApiGateway.Config
{
    public class UrlsConfig
    {
        public UrlsConfig()
        {
            equipmentOperations = new EquipmentOperations();
            scheduleOperations = new ScheduleOperations();
            clientOperations = new ClientOperations();
        }
        public class EquipmentOperations
        {
            public string AddressIP() => "dataequipment";
            public ushort Port() => 7001;
            public string GetAllEquipment() => $"http://{this.AddressIP()}:{this.Port()}/Equipment";
        }

        public class ScheduleOperations
        {
            public string AddressIP() => "dataschedule";
            public ushort Port() => 8001;
            public string GetAllReservations() => $"http://{this.AddressIP()}:{this.Port()}/Schedule/reservationmodels";
            public string PostNewReservation() => $"http://{this.AddressIP()}:{this.Port()}/Schedule";
            public string GetReservationsByDateScope() => $"http://{this.AddressIP()}:{this.Port()}/Schedule/reservationsbydate";
        }

        public class ClientOperations
        {
            public string AddressIP() => "dataclient";
            public ushort Port() => 9001;
            public string GetClientDataAsync() => $"http://{this.AddressIP()}:{this.Port()}/Clients";
        }

        public EquipmentOperations equipmentOperations { get; set; }
        public ScheduleOperations scheduleOperations { get; set; }
        public ClientOperations clientOperations { get; set; }
    }
}
