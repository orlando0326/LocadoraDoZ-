using Locadora_ze.api.data;
using Locadora_ze.api.models;
using LocadoraDoZe.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace LocadoraDoZe.Api.Controllers
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
        public async Task<ActionResult<IEnumerable<locacao>>> GetLocacao()
        {
            return await _Context.locacoes.ToListAsync();
        }
        [HttpPost]
        public async Task<IActionResult> PostLocacao(locacao locacao)
        {
            var LocacaoExiste = await _Context.locacoes.AnyAsync(d => d.Id == locacao.Id);
            if (!LocacaoExiste) { return BadRequest("Locação não existe"); }
            _Context.locacoes.Add(locacao);
            await _Context.SaveChangesAsync();
            return Ok("Locação criada com sucesso");
        }
    }
}