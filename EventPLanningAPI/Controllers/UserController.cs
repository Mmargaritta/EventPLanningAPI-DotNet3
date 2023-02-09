using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventPLanningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private DataContext _context;
        public UserController(DataContext context) 
        {
            _context = context;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<User>> GetAsync()
        {
            return await _context.Users.Select(u => new User()
            { UserId = u.UserId, UserName = u.UserName, Events = u.Events})
                .ToListAsync();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<User?> GetAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task PostAsync([FromBody] User value)
        {
            await _context.Users.AddAsync(value);
            await _context.SaveChangesAsync();
        }


        // POST api/<UserController>
        [HttpPost]
        [Route("/addevent")]
        public async Task<IActionResult> AddUserToEventAsync(int userId, int eventId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
            if (user == null) return BadRequest("user not found");
            var eventPlanning = await _context.Events.FirstOrDefaultAsync(u => u.EventId == eventId);
            if (eventPlanning == null) return BadRequest("event not found");
            if (user.Events.Any(e => e.EventId == eventId))
                return Ok();
            user.Events.Add(eventPlanning);
            await _context.SaveChangesAsync();
                return Ok();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            if (user == null) return; 
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
