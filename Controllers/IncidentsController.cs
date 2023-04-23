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
        public async Task<IEnumerable<IncidentDto>> GetIncidentsAsync()
        {
            var Incidents = (await repository.GetIncidentsAsync())
                            .Select(Incident => Incident.AsDto());
            return Incidents;
        }

        // GET /Incidents/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<IncidentDto>> GetIncidentAsync(Guid id)
        {
            var Incident = await repository.GetIncidentAsync(id);

            if (Incident is null)
            {
                return NotFound();
            }
            return Incident.AsDto();

        }

        // POST /Incident
        [HttpPost]
        public async Task<ActionResult<IncidentDto>> CreateIncidentAsync(CreateIncidentDto IncidentDto)
        {
            Incident Incident = new()
            {
                Id = Guid.NewGuid(),
                Description = IncidentDto.Description,
                CreatedDate = DateTime.UtcNow

            };

            await repository.CreateIncidentAsync(Incident);
            return CreatedAtAction(nameof(GetIncidentAsync), new { id = Incident.Id}, Incident.AsDto());
        }

        // PUT /Incidents/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateIncidentAsync(Guid id, UpdateIncidentDto IncidentDto)
        {
            var existingIncident = await repository.GetIncidentAsync(id);
            if (existingIncident is null)
            {
                return NotFound();
            }
            
            Incident updatedIncident = existingIncident with
            {
                Description = IncidentDto.Description
            };

            await repository.UpdateIncidentAsync(updatedIncident);
            return NoContent();
        }

        // DELETE /items/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteIncidentAsync(Guid id)
        {
            var existingIncident = await repository.GetIncidentAsync(id);
            if (existingIncident is null)
            {
                return NotFound();
            }
            await repository.DeleteIncidentAsync(id); 
            return NoContent();


        }

    }
}