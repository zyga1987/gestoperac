using System.ComponentModel.DataAnnotations;

namespace GestOperac.Dtos
{
    public record CreateIncidentDto
    {
        [Required]
        public string Description { get; set; }

    }
}
