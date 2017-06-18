using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SOS.Api.Entities;
using SOS.Api.Extensions;
using SOS.Api.Models;
using SOS.Api.Models.Requests;
using SOS.Api.Models.Response;
using SOS.Api.Respository;

namespace SOS.Api.Controllers
{
    [Route("api/[controller]")]
    public class IncidentController : Controller
    {
        private readonly IIncidentRepository _incidentRepository;

        public IncidentController(IIncidentRepository incidentRepository)
        {
            _incidentRepository = incidentRepository;
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "Get Incident By Id")]
        [Produces(typeof(ReportIncidentResponse))]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
            {
                return BadRequest("Id cannot be 0");
            }
            
            var incident = await _incidentRepository.GetIncident(id).ConfigureAwait(false);

            if (incident == null)
            {
                return NotFound();
            }

            return Ok(incident.ToIncidentResponse());
        }
        
        // GET api/values/5
        [HttpGet("reference/{reference}", Name = "Get Incident By Reference")]
        [Produces(typeof(ReportIncidentResponse))]
        public async Task<IActionResult> Get(string reference)
        {
            if (string.IsNullOrEmpty(reference))
            {
                return BadRequest("Reference cannot be empty");
            }

            var guidRef = Guid.Parse(reference);
            
            var incident = await _incidentRepository.GetIncident(guidRef).ConfigureAwait(false);

            if (incident == null)
            {
                return NotFound();
            }

            return Ok(incident.ToIncidentResponse());
        }

        // POST api/values
        [HttpPost(Name = "Create an incident")]
        [Produces(typeof(ReportIncidentResponse))]
        public async Task<IActionResult> ReportIncident([FromBody] ReportIncidentRequest incidentRequest)
        {
            var incident = new IncidentEntity()
            {
                AudienceType = incidentRequest.Audience.Type,
                Description = incidentRequest.Situation.Description,
                Latitude = incidentRequest.Location.Latitude,
                Longitude = incidentRequest.Location.Longitude,
                NoOfAudience = incidentRequest.Audience.Number,
                Reference = Guid.NewGuid(),
            };

            var createdIncident = await _incidentRepository.AddIncident(incident).ConfigureAwait(false);

            var incidentResponse = createdIncident.ToIncidentResponse();
            return Ok(incidentResponse);
        }
    }
}