using System;
using System.Threading.Tasks;
using SOS.Api.Entities;

namespace SOS.Api.Respository
{
    public interface IIncidentRepository
    {
        Task<IncidentEntity> AddIncident(IncidentEntity incident);

        Task<IncidentEntity> GetIncident(long id);
        
        Task<IncidentEntity> GetIncident(Guid reference);
    }
}