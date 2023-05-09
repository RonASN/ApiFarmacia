using ApiFarmacia.Controller.Models;
using ApiFarmacia.Controllers.Models;
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
            try
            {
                var clientes = await context.Clientes.ToListAsync();
                return Ok(new ResultModel<List<Cliente>>(clientes));
            }
            catch
            {
                return StatusCode(500, new ResultModel<List<Cliente>>("05x04 - Falha onterna no servidor"));
            }
        }

        [HttpGet("cliente/buscar/{id:int}")]
        public async Task<IActionResult> GetAsync([FromServices] AppDbContext context, [FromRoute] int id)
        {
            var cliente = await context.Clientes.FirstOrDefaultAsync(x => x.Id == id);

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpPost("cliente/criar")]
        public async Task<IActionResult> PostAsync([FromServices] AppDbContext context, [FromBody] ClienteModel model)
        {
            try
            {
                var cliente = new Cliente
                {
                    Id = 0,
                    Cpf = model.Cpf,
                    Nome = model.Nome,
                    Email = model.Email,
                    Senha = model.Senha,
                    Estado = model.Estado,
                    Quadra = model.Quadra,
                    Conjunto = model.Conjunto,
                    Telefone = model.Telefone,
                    PedidoCliente = null
                };
                context.Clientes.Add(cliente);
                context.SaveChanges();
                return Created($"v1/cliente/{model.Id}", model);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest("Não foi possível incluir o cliente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Falha interna no servidor");
            }

        }

        [HttpPut("cliente/editar/{id:int}")]
        public async Task<IActionResult> PutAsync([FromServices] AppDbContext context, [FromRoute] int id, [FromBody] ClienteModel model)
        {
            try
            {
                var cliente = await context.Clientes.FirstOrDefaultAsync(x => x.Id == id);

                if (cliente == null) return NotFound();

                cliente.Cpf = model.Cpf;
                cliente.Nome = model.Nome;
                cliente.Email = model.Email;
                cliente.Senha = model.Senha;
                cliente.Estado = model.Estado;
                cliente.Quadra = model.Quadra;
                cliente.Conjunto = model.Conjunto;
                cliente.Telefone = model.Telefone;

                context.Clientes.Update(cliente);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateException ex)
            {
                return BadRequest("Não foi possível editar o cliente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Falha interna no servidor");
            }
        }

        [HttpDelete("cliente/apagar/{id:int}")]
        public async Task<IActionResult> PutAsync([FromServices] AppDbContext context, [FromRoute] int id)
        {
            try
            {
                var cliente = await context.Clientes.FirstOrDefaultAsync(x => x.Id == id);

                if (cliente == null) return NotFound();

                context.Clientes.Remove(cliente);
                await context.SaveChangesAsync();
                return Ok();

            }
            catch (DbUpdateException ex)
            {
                return BadRequest("Não foi possível excluir o cliente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Falha interna no servidor");
            }
        }
    }
}
