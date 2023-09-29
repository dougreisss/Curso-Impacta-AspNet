using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.AspNet._04.API.BackEnd.Models;

namespace Projeto.AspNet._04.API.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private IRepository _repository;

        public ReservasController(IRepository repository) => _repository = repository;

        [HttpGet]
        public IEnumerable<Reserva> Get() => _repository.Reservas;

        [HttpGet("{id}")]
        public ActionResult<Reserva> GetById(int id)
        {
            if(id == 0)
            {
                return BadRequest("Algum elemento de identificação deve ser passado como elemento da requisição");
            }

            return Ok(_repository[id]);
        }

        [HttpPost]
        public ActionResult<Reserva> Post([FromBody] Reserva reserva) => 
            _repository.AddReserva(new Reserva
        {
                Nome = reserva.Nome,
                Sobrenome = reserva.Sobrenome,
                PontoA = reserva.PontoA,
                PontoB = reserva.PontoB,
                Endereco = reserva.Endereco,
                CheckIn = reserva.CheckIn,
                CheckOut = reserva.CheckOut,
        });

        [HttpPut] // atributo de requisição responsavel por posibilitar a alteração/atualização de registro
        // devidamente identificado na base
        public Reserva Put([FromForm] Reserva reserva) => _repository.UpdateReserva(reserva);


        [HttpDelete("{id}")]
        public void Delete(int id) => _repository.DeleteReserva(id);
        
    }
}
