<<<<<<< HEAD
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryService.WebAPI.Data;
=======
using LibraryService.WebAPI.Data;
using LibraryService.WebAPI.Services;
>>>>>>> 786e1f862257c28bd0a32b65a69c11fd44345073
using Microsoft.AspNetCore.Mvc;

namespace LibraryService.WebAPI.Controllers
{
    [ApiController]
<<<<<<< HEAD
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
=======
    [Route("api/fraud")]
    public class FraudController : ControllerBase
    {
        private readonly IFraudService _fraudService;

        public FraudController(IFraudService fraudService)
        {
            _fraudService = fraudService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fraud>>> GetFrauds()
        {
            var frauds = await _fraudService.GetAllAsync();
            return Ok(frauds);
        }

        [HttpPost]
        public async Task<ActionResult<Fraud>> CreateFraud([FromBody] Fraud fraud)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrWhiteSpace(fraud.ImpostorDetails) || string.IsNullOrWhiteSpace(fraud.ContactInfo))
            {
                return BadRequest("ImpostorDetails and ContactInfo are required.");
            }

            var created = await _fraudService.CreateAsync(fraud);
            return CreatedAtAction(nameof(GetFrauds), new { id = created.Id }, created);
>>>>>>> 786e1f862257c28bd0a32b65a69c11fd44345073
        }
    }
}
