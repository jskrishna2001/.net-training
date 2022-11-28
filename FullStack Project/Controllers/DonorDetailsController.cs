using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BloodBankManagementSystem.Models;
using BloodBankManagementSystem.database;

namespace BloodBankManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorDetailsController : ControllerBase
    {
        private readonly DonorContext _context;

        public DonorDetailsController(DonorContext context)
        {
            _context = context;
        }

        // GET: api/DonorDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonorDetails>>> GetDonorDetails()
        {
            return await _context.DonorDetails.ToListAsync();
        }

        // GET: api/DonorDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DonorDetails>> GetDonorDetails(int id)
        {
            var donorDetails = await _context.DonorDetails.FindAsync(id);

            if (donorDetails == null)
            {
                return NotFound();
            }

            return donorDetails;
        }

        // PUT: api/DonorDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonorDetails(int id, DonorDetails donorDetails)
        {
            if (id != donorDetails.donorId)
            {
                return BadRequest();
            }

            _context.Entry(donorDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonorDetailsExists(id))
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

        // POST: api/DonorDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DonorDetails>> PostDonorDetails(DonorDetails donorDetails)
        {
            _context.DonorDetails.Add(donorDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDonorDetails", new { id = donorDetails.donorId }, donorDetails);
        }

        // DELETE: api/DonorDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonorDetails(int id)
        {
            var donorDetails = await _context.DonorDetails.FindAsync(id);
            if (donorDetails == null)
            {
                return NotFound();
            }

            _context.DonorDetails.Remove(donorDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DonorDetailsExists(int id)
        {
            return _context.DonorDetails.Any(e => e.donorId == id);
        }
    }
}
