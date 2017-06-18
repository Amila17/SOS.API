using System;

namespace SOS.Api.Entities
{
    public class IncidentEntity
    {
        public long Id { get; set; }
        public Guid Reference { get; set; }
        public string Description { get; set; }
        public string AudienceType { get; set; }
        public int NoOfAudience { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}