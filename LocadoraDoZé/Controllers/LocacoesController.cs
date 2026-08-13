using Locadora_ze.api.data;
using LocadoraDoZe.Models;
using LocadoraDoZe.Models.LocadoraDoZe.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LocadoradoZe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        private readonly AppDbContext _Context;
        public LocacaoController(AppDbContext context)
        {
            _Context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<locacoes>>> GetLocacao()
        {
            return await _Context.locacoes.ToListAsync();
        }
        [HttpPost]
        public async Task<IActionResult> PostLocacao(locacoes locacao)
        {
            var LocacaoExiste = await _Context.locacoes.AnyAsync(d => d.Id == locacao.Id);
            if (!LocacaoExiste) { return BadRequest("Locação não existe"); }
            _Context.locacoes.Add(locacao);
            await _Context.SaveChangesAsync();
            return Ok("Locação criada com sucesso");
        }
    }
}