using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetmicroservicetwo.Models;

namespace dotnetmicroservicetwo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintController : ControllerBase
    {
        private readonly ComplaintDbContext _context;

        public ComplaintController(ComplaintDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Complaint>>> GetAllComplaints()
        {
            var complaints = await _context.Complaints.ToListAsync();
            return Ok(complaints);
        }

        [HttpPost]
        public async Task<ActionResult> AddComplaint(Complaint complaint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return detailed validation errors
            }
            await _context.Complaints.AddAsync(complaint);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComplaint(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid Complaint id");

            var complaint = await _context.Complaints.FindAsync(id);
              _context.Complaints.Remove(complaint);
                await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
