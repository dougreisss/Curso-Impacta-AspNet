using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Projeto.AspNet._05.BackEnd.WebAPI.Controllers.Data.Entity
{
    
    public class Estudante
    {
        [Key]
        public int Estudante_Id { get; set; }
        public string? Estudante_Nome { get; set; }
        public string? Estudante_Sobrenome { get; set; }
        public int? Estudante_RA { get; set; }
        public string? Estudante_Email { get; set; }
        public int Estudante_Idade { get; set; }
        public string? Estudante_Fone { get; set; }
        public string? Estudante_Genero { get; set; }
    }
}
