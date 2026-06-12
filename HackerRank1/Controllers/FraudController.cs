using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryService.WebAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace LibraryService.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FraudController : ControllerBase
    {
        private readonly LibraryContext _context;

        public FraudController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FraudReport>>> Get()
        {
            return Ok(_context.FraudReports.OrderByDescending(x => x.CreatedAt).ToList());
        }

        [HttpPost]
        public async Task<ActionResult<FraudReport>> Post(FraudReport report)
        {
            if (string.IsNullOrWhiteSpace(report.ImpostorDetails) || string.IsNullOrWhiteSpace(report.ContactInfo))
            {
                return BadRequest("Los campos de detalles del impostor y contacto son obligatorios.");
            }

            _context.FraudReports.Add(report);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = report.Id }, report);
        }
    }
}
