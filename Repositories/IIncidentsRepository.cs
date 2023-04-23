

using GestOperac.Models;

namespace GestOperac.Repositories
{
    public interface IIncidentsRepository
    {
        Incident GetIncident(Guid id);
        IEnumerable<Incident> GetIncidents();
        void CreateIncident (Incident incident);
        void UpdateIncident (Incident incident); 
        void DeleteIncident (Guid id);

    }
}