using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Projeto.AspNet._05.BackEnd.WebAPI.Controllers.Data.Entity
{
    
    public class Estudante
    {
        [Key]
        public int EstudanteId { get; set; }
        public string? EstudanteNome { get; set; }
        public string? EstudanteSobrenome { get; set; }
        public int? EstudanteRA { get; set; }
        public string? EstudanteEmail { get; set; }
        public int EstudanteIdade { get; set; }
        public string? EstudanteFone { get; set; }
        public string? EstudanteGenero { get; set; }
        public ICollection<Curso>? Curso { get; set; }
    }
}
