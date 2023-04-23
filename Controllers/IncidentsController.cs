using Microsoft.AspNetCore.Mvc;
using GestOperac.Dtos;
using GestOperac.Repositories;
using GestOperac.Models;

namespace GestOperac.Controllers
{
    [ApiController]
    [Route("Incidents")]
    public class IncidentsController : ControllerBase
    {
        private readonly IIncidentsRepository repository;

        public IncidentsController(IIncidentsRepository repository)
        {
            this.repository = repository;
        }
        // GET /Incidents
        [HttpGet]
        public IEnumerable<IncidentDto> GetIncidents()
        {
            var Incidents = repository.GetIncidents().Select(Incident => Incident.AsDto());
            return Incidents;
        }

        // GET /Incidents/{id}
        [HttpGet("{id}")]
        public ActionResult<IncidentDto> GetIncident(Guid id)
        {
            var Incident = repository.GetIncident(id);

            if (Incident is null)
            {
                return NotFound();
            }
            return Incident.AsDto();

        }

        // POST /Incident
        [HttpPost]
        public ActionResult<IncidentDto> CreateIncident(CreateIncidentDto IncidentDto)
        {
            Incident Incident = new()
            {
                Id = Guid.NewGuid(),
                Description = IncidentDto.Description,
                CreatedDate = DateTime.UtcNow

            };

            repository.CreateIncident(Incident);
            return CreatedAtAction(nameof(GetIncident), new { id = Incident.Id}, Incident.AsDto());
        }

        // PUT /Incidents/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateIncident(Guid id, UpdateIncidentDto IncidentDto)
        {
            var existingIncident = repository.GetIncident(id);
            if (existingIncident is null)
            {
                return NotFound();
            }
            
            Incident updatedIncident = existingIncident with
            {
                Description = IncidentDto.Description
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