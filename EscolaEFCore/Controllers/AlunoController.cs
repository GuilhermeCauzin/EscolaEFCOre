using Entidades;
using EscolaEFCore.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EscolaEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly EscolaContext _context;

        public AlunoController(EscolaContext _context)
        {
           this._context = _context;
        }

        private bool AlunoExists(int id)
        {
            return _context.Alunos.Any(e => e.RM == id);
        }


        [HttpGet]
        public async Task<ActionResult<List<Aluno>>> BuscarTodos()
        {
            var alunos = await this._context.Alunos.ToListAsync();
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> Buscar(int id)
        {
            var Aluno = await this._context.Alunos.FindAsync(id);

            if (Aluno == null)
            {
                return NotFound();
            }

            return Ok(Aluno);
        }

        [HttpPost]
        public async Task<ActionResult<Aluno>> Enviar(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Buscar), new { id = aluno.RM }, aluno);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Aluno>> Atualizar(int id, Aluno aluno)
        {
            if (id != aluno.RM)
            {
                return BadRequest();
            }

            _context.Entry(aluno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!AlunoExists(id))
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
        public async Task<ActionResult<Aluno>> Excluir(int id)
        {
            var Aluno = await _context.Alunos.FindAsync(id);
            if (Aluno == null)
            {
                return NotFound();
            }
            _context.Alunos.Remove(Aluno);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
