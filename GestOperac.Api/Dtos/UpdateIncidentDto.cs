using System.ComponentModel.DataAnnotations;

namespace GestOperac.Api.Dtos
{
    public record UpdateIncidentDto
    {
        [Required]
        public string Description { get; set; }

    }
}
