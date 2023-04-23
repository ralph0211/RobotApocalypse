using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RobotApocalypse.Data;
using RobotApocalypse.Dtos;
using RobotApocalypse.Models;
using System.Text.Json.Serialization;
using System.Text.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using RobotApocalypse.Exceptions;

namespace RobotApocalypse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurvivorsController : ControllerBase
    {
        private readonly RobotContext _context;
        private readonly IMediator _mediator;

        public SurvivorsController(RobotContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        // GET: api/Survivors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Survivor>>> GetSurvivors()
        {
            if (_context.Survivors == null)
            {
                return NotFound();
            }

            var survivors = await _context.Survivors
                .Include(s => s.InfectionReports)
                .ToListAsync();

            var reportedInfections = await _context.ReportedInfections.ToListAsync();

            survivors = survivors.Select(s => new Survivor
            {
                Id = s.Id,
                Name = s.Name,
                Age = s.Age,
                Gender = s.Gender,
                IsInfected = s.IsInfected,
                LastLocationLatitude = s.LastLocationLatitude,
                LastLocationLongitude = s.LastLocationLongitude,
                Resources = s.Resources,
                InfectionReports = reportedInfections.Where(ir => ir.InfectedSurvivorId == s.Id)
                    .ToList()
            }).ToList();

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            var json = JsonSerializer.Serialize(survivors, options);

            return Content(json, "application/json");
        }

        // GET: api/Survivors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Survivor>> GetSurvivor(long id)
        {
          if (_context.Survivors == null)
          {
              return NotFound();
          }
            var survivor = await _context.Survivors.FindAsync(id);

            if (survivor == null)
            {
                return NotFound();
            }

            return survivor;
        }

        // PUT: api/Survivors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSurvivor(long id, Survivor survivor)
        {
            if (id != survivor.Id)
            {
                return BadRequest();
            }

            _context.Entry(survivor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SurvivorExists(id))
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

        // POST: api/Survivors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Survivor>> PostSurvivor(CreateSurvivorCommandDto request)
        {
            var response = await _mediator.Send(request);

            if (response != null)
            {
                return CreatedAtAction("GetSurvivor", new { id = response }, response);
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/Survivors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurvivor(long id)
        {
            if (_context.Survivors == null)
            {
                return NotFound();
            }
            var survivor = await _context.Survivors.FindAsync(id);
            if (survivor == null)
            {
                return NotFound();
            }

            _context.Survivors.Remove(survivor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("updateSurvivorLocation")]
        public async Task<IActionResult> UpdateSurvivorLocation(UpdateSurvivorLocationCommandDto request)
        {
            //update survivor's location
            var survivor = await _context.Survivors.FindAsync(request.SurvivorId);

            if (survivor == null)
            {
                return NotFound();
            }

            survivor.LastLocationLatitude = request.NewLatitude;
            survivor.LastLocationLongitude = request.NewLongitude;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("flagSurvivorAsInfected")]
        public async Task<IActionResult> FlagSurvivor(FlagSurvivorCommandDto request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return Ok(response);
            } catch (EntityNotFoundException ex)
            {
                return BadRequest(ex.Message);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("infectionRates")]
        public async Task<IActionResult> InfectionRates()
        {
            //provide infected and uninfected rate as percentage in 1 response
            var query = from s in _context.Survivors
                        group s by s.IsInfected into i
                        select new
                        {
                            IsInfected = i.Key,
                            Count = i.Count(),
                            Percentage = (double)i.Count() / _context.Survivors.Count() * 100
                        };

            return Ok(query);
        }

        [HttpGet("infectionList/{isInfected}")]
        public async Task<IActionResult> InfectionList(bool isInfected)
        {
            if (isInfected)
            {
                var list = await _context.Survivors.Where(s => s.IsInfected).ToListAsync();
                return Ok(list);
            }
            else
            {
                var list = await _context.Survivors.Where(s => !s.IsInfected).ToListAsync();
                return Ok(list);
            }
        }

        private bool SurvivorExists(long id)
        {
            return (_context.Survivors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
