using Occurrence.Dtos;
using Occurrence.Models;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Occurrence
{
    public static class Extension
    {
        public static IncidentDto AsDto(this Incident incident)
        {
            return new IncidentDto
            {

                Id = incident.Id,
                CreatedDate = incident.CreatedDate,
                Description = incident.Description


            };
        }
    }
}
