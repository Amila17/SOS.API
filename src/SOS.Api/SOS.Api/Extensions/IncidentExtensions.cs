using SOS.Api.Entities;
using SOS.Api.Models;
using SOS.Api.Models.Response;

namespace SOS.Api.Extensions
{
    public static class IncidentExtensions
    {
        public static ReportIncidentResponse ToIncidentResponse(this IncidentEntity entity)
        {
            return new ReportIncidentResponse
            {
                CreatedDate = entity.CreatedDate,
                Id = entity.Id,
                Location = new Location()
                {
                    Latitude = entity.Latitude,
                    Longitude = entity.Longitude
                },
                Reference = entity.Reference.ToString()
            };
        }
    }
}