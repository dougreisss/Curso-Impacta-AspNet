using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.AspNet._05.BackEnd.WebAPI.Controllers.Data.Entity;
using Projeto.AspNet._05.BackEnd.WebAPI.Controllers.Data.MeuDbContext;

namespace Projeto.AspNet._05.BackEnd.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JoinController : ControllerBase
    {
        private readonly MeuDbContext _meuDbContext;

        public JoinController(MeuDbContext meuDbContext)
        {
            _meuDbContext = meuDbContext;
        }

        [HttpGet]
        [Route("GetJoinTodosCursos")]
        public async Task<ActionResult> GetJoinTodos()
        {
            var cursoComEstudantes = await _meuDbContext.Curso
                .Include(cs => cs.Estudante).ToListAsync();

            return Ok(cursoComEstudantes);
        }

        [HttpGet]
        [Route("buscaParametro")]
        public async Task<ActionResult> buscaFiltrada(string termo)
        {
            var resultadoFiltrado = await _meuDbContext.Curso.Where(
                cs => cs.CursoNome.Contains(termo)).Include(t => t.Estudante).ToListAsync();

            return Ok(resultadoFiltrado);
        }

        [HttpGet]
        [Route("GetJoinTodosOsEstudantes")]
        public async Task<ActionResult<IEnumerable<Estudante>>> GetEstudantesComCursos()
        {
            var estudantesComCursos = await _meuDbContext.Estudante
                .Include(e => e.Curso).ToListAsync();

            return Ok(estudantesComCursos);
        }

        [HttpGet]
        [Route("GetJoinUnicoEstudante/{estudanteId}")]
        public async Task<ActionResult> GetJoinUnicoEstudante(int estudanteId)
        {
            var unicoEstudante = _meuDbContext.Estudante
                .Include(e => e.Curso)
                .Where(e => e.EstudanteId == estudanteId).First();

            return Ok(unicoEstudante);
        }
    }
}
