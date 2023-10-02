using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.AspNet._05.BackEnd.WebAPI.Controllers.Data.Entity;
using Projeto.AspNet._05.BackEnd.WebAPI.Controllers.Data.MeuDbContext;

namespace Projeto.AspNet._05.BackEnd.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly MeuDbContext _dbContext;
        public CursoController(MeuDbContext meuDbContext)
        {
            _dbContext = meuDbContext;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> Get()
        {
            var listaCurso = await _dbContext.Curso.ToListAsync();
            return Ok(listaCurso);
        }

        [HttpGet]
        [Route("GetOne/{id}")]
        public async Task<ActionResult> GetOne(int id)
        {
            var cursoUnico = await _dbContext.Curso.FindAsync(id);

            if (cursoUnico == null)
            {
                return NotFound();
            }

            return Ok(cursoUnico);
        }

        [HttpPost]
        [Route("AddRegister")]
        public async Task<ActionResult> Post(Curso registro)
        {
            _dbContext.Curso.Add(registro);
            await _dbContext.SaveChangesAsync();

            return Ok(registro);
        }

        [HttpPut]
        [Route("UpRegister/{id}")]
        public async Task<ActionResult> PutRegister([FromRoute] int id, Curso novoRegistro)
        {
            var buscandoCurso = await _dbContext.Curso.FindAsync(id);

            if (buscandoCurso is null)
            {
                return NotFound();
            }

            buscandoCurso.CursoNome = novoRegistro.CursoNome;
            buscandoCurso.CursoMensalidade = novoRegistro.CursoMensalidade;
            buscandoCurso.EstudanteRA = novoRegistro.EstudanteRA;

            await _dbContext.SaveChangesAsync();

            return Ok(buscandoCurso);
        }

        [HttpDelete]
        [Route("delRegister/{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            var excluirRegistro = await _dbContext.Curso.FindAsync(id);

            if (excluirRegistro is null)
            {
                return NotFound();
            }

            _dbContext.Curso.Remove(excluirRegistro);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
