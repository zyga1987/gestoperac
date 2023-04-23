

using GestOperac.Models;

namespace GestOperac.Repositories
{
    public interface IIncidentsRepository
    {
        Task<Incident> GetIncidentAsync(Guid id);
        Task<IEnumerable<Incident>> GetIncidentsAsync();
        Task CreateIncidentAsync (Incident incident);
        Task UpdateIncidentAsync (Incident incident);
        Task DeleteIncidentAsync (Guid id);

    }
}