using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPLanningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventPlanningController : ControllerBase
    {
        private readonly DataContext _context;
        public EventPlanningController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.EventPlanning>>> Get()
        {
            return Ok(await _context.EventPlannings.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.EventPlanning>> Get(int id)
        {
            var planning = await _context.EventPlannings.FindAsync(id);
            if (planning == null)
                return BadRequest("Planning not found.");
            return Ok(planning);
        }

        [HttpPost]
        public async Task<ActionResult<List<Models.EventPlanning>>> AddPlanning(Models.EventPlanning planning)
        {
            _context.EventPlannings.Add(planning);
            await _context.SaveChangesAsync();

            return Ok(await _context.EventPlannings.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Models.EventPlanning>>> UpdatePlanning(Models.EventPlanning request)
        {
            var dbPlanning = await _context.EventPlannings.FindAsync(request.Id);
            if (dbPlanning == null)
                return BadRequest("Planning not found.");

            dbPlanning.Name = request.Name;
            dbPlanning.FirstName = request.FirstName;
            dbPlanning.LastName = request.LastName;
            dbPlanning.Place = request.Place;

            await _context.SaveChangesAsync();  

            return Ok(await _context.EventPlannings.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Models.EventPlanning>>> Delete(int id)
        {
            var dbPlanning = await _context.EventPlannings.FindAsync(id);
            if (dbPlanning == null)
                return BadRequest("Planning not found.");

            _context.EventPlannings.Remove(dbPlanning);
            await _context.SaveChangesAsync();

            return Ok(await _context.EventPlannings.ToListAsync());
        }
    }
}
