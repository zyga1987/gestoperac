

using GestOperac.Api.Models;

namespace GestOperac.Api.Repositories
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