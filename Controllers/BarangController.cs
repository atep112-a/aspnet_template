using System.Reflection.Metadata.Ecma335;
using ApiBarang.Model;
using ApiUsers.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ApiBarang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BarangController : ControllerBase
    {

        private readonly AppDbContext _dbContext;

        public BarangController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<BarangModel>>> GetBarang()
        {
            if (_dbContext.Barangs == null)
            {
                return NotFound();
            }
            return await _dbContext.Barangs.ToListAsync();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<IEnumerable<BarangModel>>> GetBarangById(int id)
        {
            if (_dbContext.Barangs == null)
            {
                return NotFound();
            }

            var dataBarang = await _dbContext.Barangs.FindAsync(id);
            if (dataBarang == null)
            {
                return NotFound();
            }

            return Ok(dataBarang);
        }

        [HttpPost]

        public async Task<ActionResult<BarangModel>> PostDataBarang(BarangModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            _dbContext.Barangs.Add(model);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBarang), new { id = model.Id }, model);
        }

        private bool BarangAvailable(int id)
        {
            return (_dbContext.Barangs?.Any(b => b.Id == id)).GetValueOrDefault();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditBarang(int id, BarangModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(model).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (BarangAvailable(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteBarang(int id)
        {
            if (_dbContext.Barangs == null)
            {
                return BadRequest();
            }

            var databarang = await _dbContext.Barangs.FindAsync(id);
            if (databarang == null)
            {
                return NotFound();
            }

            _dbContext.Barangs.Remove(databarang);

            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
