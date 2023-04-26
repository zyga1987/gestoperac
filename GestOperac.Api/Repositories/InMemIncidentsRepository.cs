using GestOperac.Api.Models;

namespace GestOperac.Api.Repositories
{
    public class InMemIncidentsRepository : IIncidentsRepository
    {
        private readonly List<Incident> incidents = new()
        {
            new Incident {
                Id = Guid.NewGuid(),
                CreatedDate = DateTimeOffset.UtcNow,
                Description = "Teste Ocorr�ncia 1"

            }
        };

        public async Task<IEnumerable<Incident>> GetIncidentsAsync()
        {
            return await Task.FromResult(incidents);
        }

        public async Task<Incident> GetIncidentAsync(Guid id)
        {
            var incident = incidents.Where(incident => incident.Id == id).SingleOrDefault();
            return await Task.FromResult(incident);
        }

        public async Task CreateIncidentAsync(Incident incident)
        {
            incidents.Add(incident);
            await Task.CompletedTask;
        }

        public async Task UpdateIncidentAsync(Incident incident)
        {
            var index = incidents.FindIndex(existingIncident => existingIncident.Id == incident.Id);
            incidents[index] = incident;
            await Task.CompletedTask;
        }

        public async Task DeleteIncidentAsync(Guid Id)
        {
            var index = incidents.FindIndex(existingIncident => existingIncident.Id == Id);
            incidents.RemoveAt(index);
            await Task.CompletedTask;

        }
    }
}
