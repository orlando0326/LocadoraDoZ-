using Locadora_ze.api.data;

using LocadoraDoZe.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDoZe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatineteController : ControllerBase
    {
        private readonly AppDbContext _Context;
        public PatineteController(AppDbContext context)
        {
            _Context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patinetes>>> GetPatinete()
        {
            return await _Context.patinetes.ToListAsync();
        }
        [HttpPost]
        public async Task<IActionResult> PostPatinete(Patinetes patinete)
        {
            var LocacaoExiste = await _Context.locacoes.AnyAsync(d => d.Id == patinete.Id);
            if (!LocacaoExiste) { return BadRequest("Locação não existe"); }
            _Context.patinetes.Add(patinete);
            await _Context.SaveChangesAsync();
            return Ok("Patinete comprado com sucesso");
        }
    }
}