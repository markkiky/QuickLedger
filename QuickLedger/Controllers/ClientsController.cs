#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuickLedger.Models;

namespace QuickLedger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ClientContext _context;

        public ClientsController(ClientContext context)
        {
            _context = context;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDTO>>> GetClientDTO()
        {
            return await _context.ClientDTO.ToListAsync();
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDTO>> GetClientDTO(long id)
        {
            var clientDTO = await _context.ClientDTO.FindAsync(id);

            if (clientDTO == null)
            {
                return NotFound();
            }

            return clientDTO;
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientDTO(long id, ClientDTO clientDTO)
        {
            if (id != clientDTO.Id)
            {
                return BadRequest();
            }

            _context.Entry(clientDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientDTOExists(id))
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

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Client>> PostClientDTO(ClientDTO clientDTO)
        {
            _context.ClientDTO.Add(clientDTO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientDTO", new { id = clientDTO.Id }, clientDTO);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientDTO(long id)
        {
            var clientDTO = await _context.ClientDTO.FindAsync(id);
            if (clientDTO == null)
            {
                return NotFound();
            }

            _context.ClientDTO.Remove(clientDTO);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientDTOExists(long id)
        {
            return _context.ClientDTO.Any(e => e.Id == id);
        }
    }
}
