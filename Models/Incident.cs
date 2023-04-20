namespace Occurrence.Models 
{
    public record Incident
    {
        public Guid Id { get; init;}
        public int Number {get; set;}
        public DateTimeOffset CreatedDate {get; set;}
        public string Description {get; set;}
        
    }
}