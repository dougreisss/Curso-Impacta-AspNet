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

            buscandoEstudante.Estudante_Nome = novoRegistro.Estudante_Nome;

            buscandoEstudante.Estudante_Sobrenome = novoRegistro.Estudante_Sobrenome;

            buscandoEstudante.Estudante_RA = novoRegistro.Estudante_RA;

            buscandoEstudante.Estudante_Email = novoRegistro.Estudante_Email;

            buscandoEstudante.Estudante_Idade = novoRegistro.Estudante_Idade;

            buscandoEstudante.Estudante_Fone = novoRegistro.Estudante_Fone;

            buscandoEstudante.Estudante_Genero = novoRegistro.Estudante_Genero;

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
