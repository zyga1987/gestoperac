using Occurrence.Models;

namespace Occurrence.Repositories
{
    public class InMemIncidentsRepository : IIncidentsRepository
    {
        private readonly List<Incident> incidents = new()
        {
            new Incident {
                Id = Guid.NewGuid(),
                CreatedDate = DateTimeOffset.UtcNow,
                Description = "Teste Ocorrência 1"

            }
        };

        public IEnumerable<Incident> GetIncidents()
        {
            return incidents;
        }

        public Incident GetIncident(Guid id)
        {
            return incidents.Where(incident => incident.Id == id).SingleOrDefault();
        }

        public void CreateIncident(Incident incident)
        {
            incidents.Add(incident);
        }

        public void UpdateIncident(Incident incident)
        {
            var index = incidents.FindIndex(existingIncident => existingIncident.Id == incident.Id);
            incidents[index] = incident;
        }

        public void DeleteIncident(Guid Id)
        {
            var index = incidents.FindIndex(existingIncident => existingIncident.Id == Id);
            incidents.RemoveAt(index);

        }
    }
}
