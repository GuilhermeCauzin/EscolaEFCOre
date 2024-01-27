using Entidades;
using EscolaEFCore.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EscolaEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasseController : ControllerBase
    {
        private readonly EscolaContext _context;

        public ClasseController(EscolaContext _context)
        {
            this._context = _context;
        }

        private bool ClasseExists(int id)
        {
            return _context.Classes.Any(e => e.Id == id);
        }


        [HttpGet]
        public async Task<ActionResult<List<Classe>>> BuscarTodos()
        {
            var Classes = await this._context.Classes.ToListAsync();
            return Ok(Classes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Classe>> Buscar(int id)
        {
            var Classe = await this._context.Classes.FindAsync(id);

            if (Classe == null)
            {
                return NotFound();
            }

            return Ok(Classe);
        }

        [HttpPost]
        public async Task<ActionResult<Classe>> Enviar(Classe Classe)
        {
            _context.Classes.Add(Classe);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Buscar), new { id = Classe.Id }, Classe);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Classe>> Atualizar(int id, Classe Classe)
        {
            if (id != Classe.Id)
            {
                return BadRequest();
            }

            _context.Entry(Classe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!ClasseExists(id))
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
        public async Task<ActionResult<Classe>> Excluir(int id)
        {
            var Classe = await _context.Classes.FindAsync(id);
            if (Classe == null)
            {
                return NotFound();
            }
            _context.Classes.Remove(Classe);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
