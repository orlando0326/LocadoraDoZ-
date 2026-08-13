using Locadora_ze.api.data;
using LocadoraDoZe.Models.LocadoraDoZe.Models;
using LocadoraDoZe.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Locadora_ze.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _Context;
        public ClientesController(AppDbContext context)
        {
            _Context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cliente>>> GetClientes()
        {
            return await _Context.clientes.ToListAsync();


        }
        [HttpPost]
        public async Task<IActionResult> PostClientes(cliente clientes)
        {
            _Context.clientes.Add(clientes);
            await _Context.SaveChangesAsync();
            return Ok("cliente criado");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> AlterarCliente(int id, cliente clientes)
        {
            if (id != clientes.Id)
            {
                return BadRequest("ta errado");
            }
            _Context.Entry(clientes).State = EntityState.Modified;
            await _Context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _Context.clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            _Context.clientes.Remove(cliente);
            await _Context.SaveChangesAsync();
            return NoContent();
        }
    }
}