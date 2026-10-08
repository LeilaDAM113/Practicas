using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonasApi.Models;

[Route("api/[controller]")]
[ApiController]
public class HomeController : ControllerBase
{
    private readonly HeroContext _context;
    public HomeController(HeroContext context)
    {
        _context = context;
    }

    // GET: api/Home
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Home>>> GetHome()
    {
        return await _context.home.ToListAsync();
    }

    // GET: api/Home/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Home>> GetHome(long id)
    {
        var home = await _context.home.FindAsync(id);

        if (home == null)
        {
            return NotFound();
        }

        return home;
    }

    // PUT: api/Home/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutHome(long? id, Home home)
    {
        if (id != home.Id)
        {
            return BadRequest();
        }

        _context.Entry(home).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!HomeExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Home
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Home>> PostHome(Home home)
    {
        _context.home.Add(home);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetHome", new { id = home.Id }, home);
    }

    // DELETE: api/Home/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHome(long? id)
    {
        var home = await _context.home.FindAsync(id);
        if (home == null)
        {
            return NotFound();
        }

        _context.home.Remove(home);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool HomeExists(long? id)
    {
        return _context.home.Any(e => e.Id == id);
    }
}
