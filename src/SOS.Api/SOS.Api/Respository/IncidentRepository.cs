using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SOS.Api.Entities;

namespace SOS.Api.Respository
{
    public class IncidentRepository : IIncidentRepository
    {
        private IList<IncidentEntity> _incidentStore;
        public IncidentRepository()
        {
            _incidentStore = new List<IncidentEntity>();
        }


        public Task<IncidentEntity> AddIncident(IncidentEntity incident)
        {
            var count = _incidentStore.Count;
            incident.Id = count + 1;
            incident.CreatedDate = DateTime.Now;
            _incidentStore.Add(incident);
            return Task.FromResult(incident);
        }

        public Task<IncidentEntity> GetIncident(long id)
        {
            return Task.FromResult(_incidentStore.FirstOrDefault(i => i.Id == id));
        }

        public Task<IncidentEntity> GetIncident(Guid reference)
        {
            return Task.FromResult(_incidentStore.FirstOrDefault(i => i.Reference == reference));
        }
    }
}