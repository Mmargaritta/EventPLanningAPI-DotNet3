namespace EventPLanningAPI.Models
{
    public class User
    {
        public User()
        {
            Events = new List<Event>();
        }
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public ICollection<Event> Events { get; set; } 
    }
}

