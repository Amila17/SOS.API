namespace SOS.Api.Models.Requests
{
    public class ReportIncidentRequest
    {
        public Audience Audience { get; set; }
        public Location Location { get; set; }
        public Situation Situation { get; set; }
    }
}