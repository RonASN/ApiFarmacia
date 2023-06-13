using ApiFarmacia.Controller.Models;
using ApiFarmacia.Controllers.Models;
using ApiFarmacia.Extensions;
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
            try
            {
                var cliente = await context.Clientes.FirstOrDefaultAsync(x => x.Id == id);

                if (cliente == null)
                    return NotFound(new ResultModel<Cliente>("Cliente não encontrado"));

                return Ok(new ResultModel<Cliente>(cliente));
            }
            catch 
            {
                return StatusCode(500, "05x04 - Falha interna no servidor");
            }
        }

        [HttpPost("cliente/criar")]
        public async Task<IActionResult> PostAsync([FromServices] AppDbContext context, [FromBody] EditorClienteModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultModel<Cliente>(ModelState.GetErrors()));

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
                return Created($"v1/cliente/{model.Id}", new ResultModel<Cliente>(cliente));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultModel<Cliente>("05x04 - Não foi possível incluir cliente"));
            }
            catch
            {
                return StatusCode(500, new ResultModel<Cliente>("05x10 - Falha interna no servidor"));
            }

        }

        [HttpPut("cliente/editar/{id:int}")]
        public async Task<IActionResult> PutAsync([FromServices] AppDbContext context, [FromRoute] int id, [FromBody] EditorClienteModel model)
        {
            try
            {
                var cliente = await context.Clientes.FirstOrDefaultAsync(x => x.Id == id);

                if (cliente == null) return NotFound(new ResultModel<Cliente>("Cliente não encontrado"));

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
                return Ok(new ResultModel<Cliente>(cliente));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultModel<Cliente>("05x04 - Não foi possível editar cliente"));
            }
            catch
            {
                return StatusCode(500, new ResultModel<Cliente>("05x10 - Falha interna no servidor"));
            }
        }

        [HttpDelete("cliente/apagar/{id:int}")]
        public async Task<IActionResult> PutAsync([FromServices] AppDbContext context, [FromRoute] int id)
        {
            try
            {
                var cliente = await context.Clientes.FirstOrDefaultAsync(x => x.Id == id);

                if (cliente == null) return NotFound(new ResultModel<Cliente>("Cliente não encontrado"));

                context.Clientes.Remove(cliente);
                await context.SaveChangesAsync();
                return Ok();

            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultModel<Cliente>("05x04 - Não foi possível excluir cliente"));
            }
            catch
            {
                return StatusCode(500, new ResultModel<Cliente>("05x10 - Falha interna no servidor"));
            }
        }
    }
}
