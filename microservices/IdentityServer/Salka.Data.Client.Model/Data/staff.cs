using System;
using System.Collections.Generic;

namespace Salka.Data.Clients.Model.Data
{
    public partial class Staff : BaseEntity
    {
        //public int StaffId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int AddressId { get; set; }
        public int RecordingStudioId { get; set; }

        public virtual Address Address { get; set; }
        public virtual RecordingStudio RecordingStudio { get; set; }
    }
}
