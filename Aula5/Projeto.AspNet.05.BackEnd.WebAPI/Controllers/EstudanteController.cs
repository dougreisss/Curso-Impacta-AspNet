using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.AspNet._05.BackEnd.WebAPI.Controllers.Data.MeuDbContext;

namespace Projeto.AspNet._05.BackEnd.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudanteController : ControllerBase
    {
        private readonly MeuDbContext _dbContext;

        public EstudanteController(MeuDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> Get()
        {
            var listaEstudantes = await _dbContext.Estudante.ToListAsync();

            return Ok(listaEstudantes);
        }

        [HttpGet]
        [Route("GetOne/{id}")]
        public async Task<ActionResult> GetOne(int id)
        {
            var estudanteUnico = await _dbContext.Estudante.FindAsync(id);

            if (estudanteUnico == null)
            {
                return NotFound();
            }

            return Ok(estudanteUnico);
        }
    }
}
