using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Collections.Immutable;

namespace Projeto.AspNet._04.API.BackEnd.Models
{
    public class Repository : IRepository
    {
        private Dictionary<int, Reserva> _registro;
        public Repository()
        { 
            _registro = new Dictionary<int, Reserva>();

            new List<Reserva>
            {
                new Reserva
                { 
                    Id = 1, 
                    Nome = "Bruno",
                    Sobrenome = "Mano",
                    PontoA = "São Paulo - Zona Norte",
                    PontoB = "Berlim - Alemanha",
                    Endereco = "Rua 1",
                    CheckIn = DateTime.Now,
                    CheckOut = DateTime.Now,
                }, 
                new Reserva 
                {
                    Id = 2,
                    Nome = "Douglas",
                    Sobrenome = "Reis",
                    PontoA = "Santos",
                    PontoB = "Berlim - Alemanha",
                    Endereco = "Rua 2",
                    CheckIn = DateTime.Now,
                    CheckOut = DateTime.Now,
                }, 
                new Reserva 
                {
                    Id = 3,
                    Nome = "Gabriela",
                    Sobrenome = "Alcaide",
                    PontoA = "Guarulhos - SP",
                    PontoB = "Lisboa - Portugal",
                    Endereco = "Rua 3",
                    CheckIn = DateTime.Now,
                    CheckOut = DateTime.Now,
                }
            }.ForEach(res => AddReserva(res));
        }
        public Reserva this[int id] => _registro.ContainsKey(id) ? _registro[id] : null;

        public IEnumerable<Reserva> Reservas => _registro.Values;

        public Reserva AddReserva(Reserva registroReserva)
        {
            if (registroReserva.Id == 0)
            {
                int key = _registro.Count;

                while (_registro.ContainsKey(key)) 
                {
                    key++;
                }

                registroReserva.Id = key;
            }

            _registro[registroReserva.Id] = registroReserva;

            return registroReserva;
        }
        public Reserva UpdateReserva(Reserva registroAtualizado) => AddReserva(registroAtualizado);
        public void DeleteReserva(int id) => _registro.Remove(id);
    }
}
