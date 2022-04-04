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
    public class UserTablesController : ControllerBase
    {
        private readonly TestApplicationContext _context;

        public UserTablesController(TestApplicationContext context)
        {
            _context = context;
        }

        // GET: api/UserTables/getAllUsers
        [HttpGet("getAllUsers")]
        public async Task<ActionResult<IEnumerable<UserTable>>> GetUserTables()
        {
            return await _context.UserTables.ToListAsync();
        }

        // GET: api/UserTables/getUser/5
        [HttpGet("getUser/{id}")]
        public async Task<ActionResult<UserTable>> GetUserTable(int id)
        {
            var userTable = await _context.UserTables.FindAsync(id);

            if (userTable == null)
            {
                return NotFound("No Record Found");
            }

            return userTable;
        }

        // PUT: api/UserTables/update/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("update/{id}")]
        public async Task<IActionResult> PutUserTable(int id, UserTable userTable)
        {
            if (id != userTable.EmpId)
            {
                return BadRequest();
            }

            _context.Entry(userTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTableExists(id))
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

        // POST: api/UserTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        /*public async Task<ActionResult<UserTable>> PostUserTable(UserTable userTable)
        {
            _context.UserTables.Add(userTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserTable", new { id = userTable.EmpId }, userTable);
        }*/

        // POST: api/UserTables/createUser
        [HttpPost("createUser")]
        public async Task<ActionResult<UserTable>> PostUserTable(UserTable userTable)
        {
            /*_context.UserTables.Add(userTable);
            await _context.SaveChangesAsync();*/

            var signUpUser = new UserTable();
            //signUpUser.EmpId = userTable.EmpId; 
            signUpUser.MailId = userTable.MailId;
            signUpUser.Password=userTable.Password;
            signUpUser.ConfirmPassword = userTable.ConfirmPassword;

            signUpUser.FirstName = userTable.FirstName;
            signUpUser.LastName = userTable.LastName;
            signUpUser.PhoneNumber = userTable.PhoneNumber;
            //signUpUser.RoleId = userTable.RoleId;
            signUpUser.ManagerId = userTable.ManagerId;
            signUpUser.City = userTable.City;
            signUpUser.State = userTable.State;
            signUpUser.AddressLine1 = userTable.AddressLine1;
            signUpUser.AddressLine2 = userTable.AddressLine2;
            signUpUser.Country = userTable.Country;
            signUpUser.Zipcode = userTable.Zipcode;

            _context.UserTables.Add(signUpUser);
            await _context.SaveChangesAsync();


            return CreatedAtAction("GetUserTable", new { id = userTable.EmpId }, userTable);
        }

        // DELETE: api/UserTables/delete/5
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUserTable(int id)
        {
            var userTable = await _context.UserTables.FindAsync(id);
            if (userTable == null)
            {
                return NotFound();
            }

            _context.UserTables.Remove(userTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserTableExists(int id)
        {
            return _context.UserTables.Any(e => e.EmpId == id);
        }
    }
}
