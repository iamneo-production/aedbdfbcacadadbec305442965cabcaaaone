using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetmicroserviceone.Models;

namespace dotnetmicroserviceone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallController : ControllerBase
    {
        private readonly CallDbContext _context;

        public CallController(CallDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Call>>> GetAllCalls()
        {
            var calls = await _context.Calls.ToListAsync();
            return Ok(calls);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Call>> GetCallById(int id)
        {
            var call = await _context.Calls.FindAsync(id);

            if (call == null)
            {
                return NotFound();
            }

            return Ok(call);
        }
        [HttpPost]
        public async Task<ActionResult> AddCall(Call call)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return detailed validation errors
            }
            await _context.Calls.AddAsync(call);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCall(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid Call id");

            var call = await _context.Calls.FindAsync(id);
              _context.Calls.Remove(call);
                await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
