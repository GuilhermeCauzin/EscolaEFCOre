using Entidades;
using EscolaEFCore.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EscolaEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscolaController : ControllerBase
    {
        private readonly EscolaContext _context;

        public EscolaController(EscolaContext _context)
        {
            this._context = _context;
        }

        private bool EscolaExists(int id)
        {
            return _context.Escolas.Any(e => e.UnidadeId == id);
        }


        [HttpGet]
        public async Task<ActionResult<List<Escola>>> BuscarTodos()
        {
            var Escolas = await this._context.Escolas.ToListAsync();
            return Ok(Escolas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Escola>> Buscar(int id)
        {
            var Escola = await this._context.Escolas.FindAsync(id);

            if (Escola == null)
            {
                return NotFound();
            }

            return Ok(Escola);
        }

        [HttpPost]
        public async Task<ActionResult<Escola>> Enviar(Escola Escola)
        {
            _context.Escolas.Add(Escola);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Buscar), new { id = Escola.UnidadeId }, Escola);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Escola>> Atualizar(int id, Escola Escola)
        {
            if (id != Escola.UnidadeId)
            {
                return BadRequest();
            }

            _context.Entry(Escola).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!EscolaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw e;
                }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Escola>> Excluir(int id)
        {
            var Escola = await _context.Escolas.FindAsync(id);
            if (Escola == null)
            {
                return NotFound();
            }
            _context.Escolas.Remove(Escola);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
