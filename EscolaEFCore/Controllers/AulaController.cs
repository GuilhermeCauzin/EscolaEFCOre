using Entidades;
using EscolaEFCore.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EscolaEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AulaController : ControllerBase
    {
        private readonly EscolaContext _context;

        public AulaController(EscolaContext _context)
        {
            this._context = _context;
        }

        private bool AulaExists(int id)
        {
            return _context.Aulas.Any(e => e.Id == id);
        }


        [HttpGet]
        public async Task<ActionResult<List<Aula>>> BuscarTodos()
        {
            var Aulas = await this._context.Aulas.ToListAsync();
            return Ok(Aulas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aula>> Buscar(int id)
        {
            var Aula = await this._context.Aulas.FindAsync(id);

            if (Aula == null)
            {
                return NotFound();
            }

            return Ok(Aula);
        }

        [HttpPost]
        public async Task<ActionResult<Aula>> Enviar(Aula Aula)
        {
            _context.Aulas.Add(Aula);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Buscar), new { id = Aula.Id }, Aula);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Aula>> Atualizar(int id, Aula Aula)
        {
            if (id != Aula.Id)
            {
                return BadRequest();
            }

            _context.Entry(Aula).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!AulaExists(id))
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
        public async Task<ActionResult<Aula>> Excluir(int id)
        {
            var Aula = await _context.Aulas.FindAsync(id);
            if (Aula == null)
            {
                return NotFound();
            }
            _context.Aulas.Remove(Aula);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
