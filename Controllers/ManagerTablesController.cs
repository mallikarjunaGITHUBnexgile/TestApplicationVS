#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApplication.Models;

namespace TestApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerTablesController : ControllerBase
    {
        private readonly TestApplicationContext _context;

        public ManagerTablesController(TestApplicationContext context)
        {
            _context = context;
        }

        // GET: api/ManagerTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManagerTable>>> GetManagerTables()
        {
            return await _context.ManagerTables.ToListAsync();
        }

        // GET: api/ManagerTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ManagerTable>> GetManagerTable(int id)
        {
            var managerTable = await _context.ManagerTables.FindAsync(id);

            if (managerTable == null)
            {
                return NotFound();
            }
            return managerTable;
        }

        // PUT: api/ManagerTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManagerTable(int id, ManagerTable managerTable)
        {
            if (id != managerTable.ManagerId)
            {
                return BadRequest();
            }

            _context.Entry(managerTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManagerTableExists(id))
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

        // POST: api/ManagerTables
        // Adding Manager
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ManagerTable>> PostManagerTable(ManagerTable managerTable)
        {
            var signUpManager = new ManagerTable();
            signUpManager.MailId = managerTable.MailId;
            signUpManager.Password = managerTable.Password;
            signUpManager.ConfirmPassword = managerTable.ConfirmPassword;

            signUpManager.FirstName = managerTable.FirstName;
            signUpManager.LastName = managerTable.LastName;
            signUpManager.PhoneNumber = managerTable.PhoneNumber;
            signUpManager.AddressLine1 = managerTable.AddressLine1;
            signUpManager.AddressLine2= managerTable.AddressLine2;  
            signUpManager.Country=  managerTable.Country;
            signUpManager.ManagerId = managerTable.ManagerId;   
            signUpManager.RoleId = managerTable.RoleId; 

            /*_context.ManagerTables.Add(managerTable);
            await _context.SaveChangesAsync();*/

            return CreatedAtAction("GetManagerTable", new { id = managerTable.ManagerId }, managerTable);
        }

        // DELETE: api/ManagerTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManagerTable(int id)
        {
            var managerTable = await _context.ManagerTables.FindAsync(id);
            if (managerTable == null)
            {
                return NotFound();
            }

            _context.ManagerTables.Remove(managerTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ManagerTableExists(int id)
        {
            return _context.ManagerTables.Any(e => e.ManagerId == id);
        }
    }
}
