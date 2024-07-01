using demo_8_may.Data;
using demo_8_may.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace demo_8_may.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternController : ControllerBase
    {
        private readonly InternDbContext _internDbContext;
        public InternController(InternDbContext internDbContext)
        {
            _internDbContext = internDbContext;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Intern>>> GetInterns()
        {
            return await _internDbContext.Interns.ToListAsync();
        }

        [HttpPost]

        public async Task<ActionResult<Intern>> PostMember(Intern intern)
        {
            _internDbContext.Interns.Add(intern);
            await _internDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInterns), new { id = intern.InternId }, intern);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Intern>> GetIntern(int id)
        {
            var intern = await _internDbContext.Interns.FindAsync(id);

            if (intern == null)
            {
                return NotFound();
            }

            return intern;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutIntern(int id, Intern intern)
        {
            if (id != intern.InternId)
            {
                return BadRequest();
            }

            _internDbContext.Entry(intern).State = EntityState.Modified;
            await _internDbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIntern(int id)
        {
            var intern = await _internDbContext.Interns.FindAsync(id);

            if (intern == null)
            {
                return NotFound();
            }

            _internDbContext.Interns.Remove(intern);
            await _internDbContext.SaveChangesAsync();

            return NoContent();
        }


    }
}
