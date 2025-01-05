using ApiUsers.Data;
using ApiUsers.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiUsers.Controllers
{

    [Route("/api[controller]")]
    [ApiController]
    public class TransaksiController : Controller
    {
        private readonly AppDbContext _DbContext;

        public TransaksiController(AppDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<TransaksiModel>>> GetTransaksi()
        {
            if (_DbContext.Transaksi == null)
            {
                return NotFound();
            }

            return await _DbContext.Transaksi.ToListAsync();
        }

        [HttpPost]

        public async Task<ActionResult<TransaksiModel>> PostTransaksi(TransaksiModel transaksi)
        {
            if (transaksi == null)
            {
                return BadRequest();
            }

            var barang = await _DbContext.Barangs.FindAsync(transaksi.id_barang);
            if (barang == null)
            {
                return NotFound();
            }

            if (barang.Stok < transaksi.jumlah)

            {
                return BadRequest("Stock not allowed");
            }

            barang.Stok -= transaksi.jumlah;

            _DbContext.Transaksi.Add(transaksi);
            await _DbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTransaksi), new {id  = transaksi.Id}, transaksi);
        }
    }
}
