using GestOperac.Dtos;
using GestOperac.Models;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestOperac
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
