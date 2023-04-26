using ApiFarmacia.Controller.Models;
using Domain.Entidades;
using Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiFarmacia.Controller
{
    [ApiController]
    [Route("v1")]
    public class ClienteController : ControllerBase
    {
        [HttpGet("cliente/lista")]
        public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
        {
            var clientes = await context.Clientes.ToListAsync();
            return Ok(clientes);
        }

        [HttpGet("cliente/buscar={id:int}")]
        public async Task<IActionResult> GetAsync([FromServices] AppDbContext context, [FromRoute] int id)
        {
            var cliente = await context.Clientes.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(cliente);
        }

        [HttpPost("cliente/criar")]
        public async Task<IActionResult> PostAsync([FromServices] AppDbContext context, [FromBody] Cliente model)
        {
            context.Clientes.Add(model);
            context.SaveChanges();
            return Created($"v1/cliente/{model.Id}",model);
        }

        [HttpPut("cliente/editar={id:int}")]
        public async Task<IActionResult> PutAsync([FromServices] AppDbContext context, [FromRoute] int id,[FromBody] Cliente model)
        {
            var cliente = await context.Clientes.FirstOrDefaultAsync(x => x.Id == id);

            if (cliente == null) return NotFound();

            cliente.Cpf = model.Cpf;    
            cliente.Nome = model.Nome;  
            cliente.Email = model.Email;
            cliente.Senha = model.Senha;
            cliente.Estado= model.Estado;   
            cliente.Quadra = model.Quadra;
            cliente.Conjunto = model.Conjunto;
            cliente.Telefone= model.Telefone;

            context.Clientes.Update(cliente);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("cliente/editar={id:int}")]
        public async Task<IActionResult> PutAsync([FromServices] AppDbContext context, [FromRoute] int id)
        {
            var cliente = await context.Clientes.FirstOrDefaultAsync(x => x.Id == id);

            if (cliente == null) return NotFound();

            context.Clientes.Remove(cliente);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
