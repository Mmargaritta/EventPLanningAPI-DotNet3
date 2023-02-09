namespace EventPLanningAPI.Models
{
    public class Event

    {
        public int EventId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime EventDate  { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}

