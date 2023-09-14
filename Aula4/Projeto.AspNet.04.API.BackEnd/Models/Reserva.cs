namespace Projeto.AspNet._04.API.BackEnd.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string? PontoA { get; set; }
        public string? PontoB { get; set; }
        public string? Endereco { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
