namespace GestOperac.Api.Dtos
{
    public record IncidentDto
    {
        public Guid Id { get; init; }
        public DateTimeOffset CreatedDate { get; set; }
        public string Description { get; set; }

    }
}
