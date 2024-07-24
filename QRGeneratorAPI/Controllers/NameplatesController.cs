using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using QRGeneratorAPI.Data;
using QRGeneratorAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRGeneratorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NameplatesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<NameplatesController> _logger;

        public NameplatesController(ApplicationDbContext context, ILogger<NameplatesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Nameplates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nameplate>>> GetNameplates()
        {
            try
            {
                var nameplates = await _context.Nameplates.ToListAsync();
                _logger.LogInformation($"Fetched Nameplates: {JsonConvert.SerializeObject(nameplates)}");
                return nameplates;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching nameplates: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/Nameplates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nameplate>> GetNameplate(int id)
        {
            try
            {
                var nameplate = await _context.Nameplates.FindAsync(id);

                if (nameplate == null)
                {
                    return NotFound();
                }

                return nameplate;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching nameplate with ID {id}: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/Nameplates
        [HttpPost]
        public async Task<ActionResult<Nameplate>> PostNameplate(Nameplate nameplate)
        {
            try
            {
                _context.Nameplates.Add(nameplate);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Received Nameplate: {JsonConvert.SerializeObject(nameplate)}");
                return CreatedAtAction(nameof(GetNameplate), new { id = nameplate.Id }, nameplate);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error saving nameplate: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/Nameplates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNameplate(int id, Nameplate nameplate)
        {
            if (id != nameplate.Id)
            {
                return BadRequest();
            }

            _context.Entry(nameplate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NameplateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating nameplate with ID {id}: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

            return NoContent();
        }

        // DELETE: api/Nameplates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNameplate(int id)
        {
            try
            {
                var nameplate = await _context.Nameplates.FindAsync(id);
                if (nameplate == null)
                {
                    return NotFound();
                }

                _context.Nameplates.Remove(nameplate);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting nameplate with ID {id}: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        private bool NameplateExists(int id)
        {
            return _context.Nameplates.Any(e => e.Id == id);
        }
    }
}
