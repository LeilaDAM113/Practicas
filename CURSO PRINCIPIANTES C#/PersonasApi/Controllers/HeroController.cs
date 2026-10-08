using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonasApi.Models;

[Route("api/[controller]")]
[ApiController]
public class HeroController : ControllerBase
{
    private readonly HeroContext _context;
    public HeroController(HeroContext context)
    {
        _context = context;
    }

    // GET: api/Hero
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Hero>>> GetHero()
    {
        return await _context.hero.ToListAsync();
    }

    // GET: api/Hero/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Hero>> GetHero(long id)
    {
        var hero = await _context.hero.FindAsync(id);

        if (hero == null)
        {
            return NotFound();
        }

        return hero;
    }

    // PUT: api/Hero/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutHero(long? id, Hero hero)
    {
        if (id != hero.Id)
        {
            return BadRequest();
        }

        _context.Entry(hero).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!HeroExists(id))
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

    // POST: api/Hero
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Hero>> PostHero(Hero hero)
    {
        _context.hero.Add(hero);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetHero", new { id = hero.Id }, hero);
    }

    // DELETE: api/Hero/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHero(long? id)
    {
        var hero = await _context.hero.FindAsync(id);
        if (hero == null)
        {
            return NotFound();
        }

        _context.hero.Remove(hero);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool HeroExists(long? id)
    {
        return _context.hero.Any(e => e.Id == id);
    }
}
