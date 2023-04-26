using System.ComponentModel.DataAnnotations;

namespace GestOperac.Api.Dtos
{
    public record CreateIncidentDto
    {
        [Required]
        public string Description { get; set; }

    }
}
