using Microsoft.AspNetCore.Mvc;

namespace EventPLanningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly DataContext _context;
        public EventController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Event>> Get()
        {
            return await _context.Events
                .Select(e => new Event() 
                {EventId = e.EventId, EventDate = e.EventDate, Name = e.Name, Description = e.Description})    
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Event?> Get(int id)
        {
            return await _context.Events.FindAsync(id);
        }

        [HttpPost]
        public async Task PostAsync([FromBody] Event value)
        {
            await _context.Events.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        [HttpPut]
        public async Task<List<Event>> UpdatePlanning()
        {
            return await _context.Events.ToListAsync();
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            var eventPlanning = await _context.Events.FirstOrDefaultAsync(u => u.EventId == id);
            if (eventPlanning == null) return;
            _context.Events.Remove(eventPlanning);
            await _context.SaveChangesAsync();
        }
    }
}
