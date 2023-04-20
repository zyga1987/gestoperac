using Microsoft.AspNetCore.Mvc;
using Occurrence;
using Occurrence.Dtos;
using Occurrence.Repositories;
using Occurrence.Models;

namespace Ocurrence.Controllers
{
    [ApiController]
    [Route("incidents")]
    public class IncidentsController : ControllerBase
    {
        private readonly IIncidentsRepository repository;

        public IncidentsController(IIncidentsRepository repository)
        {
            this.repository = repository;
        }
        // GET /incidents
        [HttpGet]
        public IEnumerable<IncidentDto> GetIncidents()
        {
            var incidents = repository.GetIncidents().Select(incident => incident.AsDto());
            return incidents;
        }

        // GET /incidents/{id}
        [HttpGet("{id}")]
        public ActionResult<IncidentDto> GetIncident(Guid id)
        {
            var incident = repository.GetIncident(id);

            if (incident is null)
            {
                return NotFound();
            }
            return incident.AsDto();

        }

        // POST /incident
        [HttpPost]
        public ActionResult<IncidentDto> CreateIncident(CreateIncidentDto incidentDto)
        {
            Incident incident = new()
            {
                Id = Guid.NewGuid(),
                Description = incidentDto.Description,
                CreatedDate = DateTime.UtcNow

            };

            repository.CreateIncident(incident);
            return CreatedAtAction(nameof(GetIncident), new { id = incident.Id}, incident.AsDto());
        }

        // PUT /incidents/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateIncident(Guid id, UpdateIncidentDto incidentDto)
        {
            var existingIncident = repository.GetIncident(id);
            if (existingIncident is null)
            {
                return NotFound();
            }
            
            Incident updatedIncident = existingIncident with
            {
                Description = incidentDto.Description
            };

            repository.UpdateIncident(updatedIncident);
            return NoContent();
        }

        // DELETE /items/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteIncident(Guid id)
        {
            var existingIncident = repository.GetIncident(id);
            if (existingIncident is null)
            {
                return NotFound();
            }
            repository.DeleteIncident(id); 
            return NoContent();


        }

    }
}