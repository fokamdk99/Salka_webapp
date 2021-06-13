using Microsoft.EntityFrameworkCore;
using Salka.Data.Clients.Model.Data;
using Salka.Data.Clients.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.Data.Clients.Logic.Interfaces
{
    public static class IAsyncRepositoryRecordingStudioExtensions
    {
        public static async Task<RecordingStudio> GetRecordingStudioByName(this IAsyncRepository<RecordingStudio> asyncRepository, string name)
        {
            using (var salkadb = new salkadbclientContext())
            {
                var recordingStudio = await salkadb.RecordingStudios.Where(rs => rs.Name == name).SingleAsync();
                return recordingStudio;
            }
        }

        public static async Task<RecordingStudio> GetRecordingStudioByClientIdAsync(this IAsyncRepository<RecordingStudio> asyncRepository, int clientId)
        {
            using (var salkadb = new salkadbclientContext())
            {
                var recordingStudio = await salkadb.Clients.Where(c => c.Id == clientId).Select(c => c.RecordingStudio).SingleOrDefaultAsync();
                return recordingStudio;
            }
        }
    }
    /*
    public class RecordingStudioRepository : IRecordingStudioRepository
    {
        public IAsyncRepository<RecordingStudio> _asyncRepository;
        public RecordingStudioRepository(IAsyncRepository<RecordingStudio> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }
        public async Task<RecordingStudio> GetRecordingStudioByClientIdAsync(int clientId)
        {
            using (var salkadb = new salkadbclientContext())
            {
                var recordingStudio = await salkadb.Clients.Where(c => c.Id == clientId).Select(c => c.RecordingStudio).SingleOrDefaultAsync();
                return recordingStudio;
            }
        }

        public async Task<RecordingStudio> GetRecordingStudioByName(string name)
        {
            using (var salkadb = new salkadbclientContext())
            {
                var recordingStudio = await salkadb.RecordingStudios.Where(rs => rs.Name == name).SingleAsync();
                return recordingStudio;
            }
        }
        public async Task<RecordingStudio> GetRecordingStudioById(int recordingStudioId)
        {
            using (var salkadb = new salkadbclientContext())
            {
                var recordingStudio = await salkadb.RecordingStudios.Where(rs => rs.Id == recordingStudioId).SingleAsync();
                return recordingStudio;
            }
        }
    }
*/
}
