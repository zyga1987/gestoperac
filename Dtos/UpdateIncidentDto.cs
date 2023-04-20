using System.ComponentModel.DataAnnotations;

namespace Occurrence.Dtos
{
    public record UpdateIncidentDto
    {
        [Required]
        public string Description { get; set; }

    }
}
