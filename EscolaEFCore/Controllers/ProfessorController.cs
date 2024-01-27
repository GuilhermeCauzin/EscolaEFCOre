using Entidades;
using EscolaEFCore.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EscolaEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly EscolaContext _context;

        public ProfessorController(EscolaContext _context)
        {
            this._context = _context;
        }

        private bool ProfExists(long id)
        {
            return _context.Professores.Any(e => e.Id == id);
        }

        [HttpGet]
        public async Task<ActionResult<List<Professor>>> BuscarTodos()
        {
            var professores = await this._context.Professores.ToListAsync();
            return Ok(professores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Professor>> Buscar(int id)
        {
            var professor = await this._context.Professores.FindAsync(id);

            if (professor == null)
            {
                return NotFound();
            }

            return Ok(professor);
        }

        [HttpPost]
        public async Task<ActionResult<Professor>> Enviar(Professor prof)
        {
            _context.Professores.Add(prof);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Buscar), new { id = prof.Id }, prof);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Professor>> Atualizar(int id, Professor prof)
        {
            if (id != prof.Id)
            {
                return BadRequest();
            }

            _context.Entry(prof).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!ProfExists(id))
                {
                    return NotFound();
                }
                else{
                    throw e;
                }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Professor>> Excluir(int id)
        {
            var professor = await _context.Professores.FindAsync(id);
            if(professor == null)
            {
                return NotFound();
            }
            _context.Professores.Remove(professor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
