using ApiUsers.Data;
using ApiUsers.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiUsers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public UsersController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersModel>>> GetUsers()
        {
            if (_dbContext.Users == null)
            {
                return NotFound();
            }

            return await _dbContext.Users.ToListAsync();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<IEnumerable<UsersModel>>> GetUsersById(int id)
        {
      
            if (_dbContext.Users == null)
            {
                return NotFound();
            }

            var dataUsers = await _dbContext.Users.FindAsync(id);
            if (dataUsers == null)
            {
                return NotFound();
            }

            return Ok(dataUsers);
        }

        [HttpPost]
        public async Task<ActionResult<UsersModel>> PostUsers(UsersModel model)
        {
            _dbContext.Users.Add(model);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsers), new { id = model.Id }, model);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> EditUsers(int id, UsersModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(model).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (UserAvailable(id))
                {
                    return NotFound();
                } else
                {
                    throw;
                }
            }

            return Ok();

        }

        private bool UserAvailable(int id)
        {
            return (_dbContext.Users?.Any(u => u.Id == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUsers(int id)
        {
            if (_dbContext.Users == null)
            {
                return NotFound();
            }

            var dataUsers = await _dbContext.Users.FindAsync(id);
            if (dataUsers == null)
            {
                return NotFound();
            }

            _dbContext.Users.Remove(dataUsers);

            await _dbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
