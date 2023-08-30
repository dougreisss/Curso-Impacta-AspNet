namespace Projeto.AspNet._04.API.BackEnd.Models
{
    public interface IRepository
    {
        IEnumerable<Reserva> Reservas { get; }

        Reserva this[int id] { get; }

        Reserva AddReserva(Reserva registroReserva);
        Reserva UpdateReserva(Reserva registroAtualizado);
        void DeleteReserva(int id);
    }
}
