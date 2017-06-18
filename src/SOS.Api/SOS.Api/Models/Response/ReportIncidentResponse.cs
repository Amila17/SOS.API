using System;

namespace SOS.Api.Models.Response
{
    public class ReportIncidentResponse
    {
        public long Id { get; set; }
        public string Reference { get; set; }
        public Location Location { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}