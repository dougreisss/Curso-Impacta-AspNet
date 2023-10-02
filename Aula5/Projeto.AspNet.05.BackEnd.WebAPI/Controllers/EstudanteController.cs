using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.AspNet._05.BackEnd.WebAPI.Controllers.Data.Entity;
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

        [HttpPost]
        [Route("AddRegister")]
        public async Task<ActionResult> Post(Estudante registro)
        {
            _dbContext.Estudante.Add(registro);
            await _dbContext.SaveChangesAsync();

            return Ok(registro);
        }

        [HttpPut]
        [Route("UpRegister/{id}")]
        public async Task<ActionResult> PutRegister([FromRoute]int id, Estudante novoRegistro)
        {
            var buscandoEstudante = await _dbContext.Estudante.FindAsync(id);

            if (buscandoEstudante is null)
            {
                return NotFound();
            }

            buscandoEstudante.EstudanteNome = novoRegistro.EstudanteNome;

            buscandoEstudante.EstudanteSobrenome = novoRegistro.EstudanteSobrenome;

            buscandoEstudante.EstudanteRA = novoRegistro.EstudanteRA;

            buscandoEstudante.EstudanteEmail = novoRegistro.EstudanteEmail;

            buscandoEstudante.EstudanteIdade = novoRegistro.EstudanteIdade;

            buscandoEstudante.EstudanteFone = novoRegistro.EstudanteFone;

            buscandoEstudante.EstudanteGenero = novoRegistro.EstudanteGenero;

            await _dbContext.SaveChangesAsync();

            return Ok(buscandoEstudante);
        }

        [HttpDelete]
        [Route("delRegister/{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            var excluirRegistro = await _dbContext.Estudante.FindAsync(id);

            if (excluirRegistro is null) 
            {
                return NotFound();
            }

            _dbContext.Estudante.Remove(excluirRegistro);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
