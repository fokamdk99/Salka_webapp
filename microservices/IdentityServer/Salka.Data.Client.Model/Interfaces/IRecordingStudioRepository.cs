using Salka.Data.Clients.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.Data.Clients.Model.Interfaces
{
    public interface IRecordingStudioRepository
    {
        Task<RecordingStudio> GetRecordingStudioByClientIdAsync(int clientId);
        Task<RecordingStudio> GetRecordingStudioByName(string name);
        Task<RecordingStudio> GetRecordingStudioById(int recordingStudioId);
    }
}
