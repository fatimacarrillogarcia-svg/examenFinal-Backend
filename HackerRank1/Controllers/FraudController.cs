using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryService.WebAPI.Data;
using LibraryService.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryService.WebAPI.Controllers
{
    [ApiController]
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
                return BadRequest("Los campos de detalles del impostor y contacto son obligatorios.");
            }

            var created = await _fraudService.CreateAsync(fraud);
            return CreatedAtAction(nameof(GetFrauds), new { id = created.Id }, created);
        }
    }
}
