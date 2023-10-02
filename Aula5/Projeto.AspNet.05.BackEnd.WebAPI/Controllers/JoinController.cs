using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    }
}
