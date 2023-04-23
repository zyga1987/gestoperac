using System.ComponentModel.DataAnnotations;

namespace GestOperac.Dtos
{
    public record UpdateIncidentDto
    {
        [Required]
        public string Description { get; set; }

    }
}
