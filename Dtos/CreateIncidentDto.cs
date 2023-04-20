using System.ComponentModel.DataAnnotations;

namespace Occurrence.Dtos
{
    public record CreateIncidentDto
    {
        [Required]
        public string Description { get; set; }

    }
}
