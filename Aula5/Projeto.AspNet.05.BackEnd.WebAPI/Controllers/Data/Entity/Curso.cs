using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.AspNet._05.BackEnd.WebAPI.Controllers.Data.Entity
{
    public class Curso
    {
        [Key]
        public int Curso_Id { get; set; }
        public string? Curso_Nome { get; set; }
        public decimal Curso_Mensalidade { get; set; }
        [ForeignKey("Estudante_Id")]
        public int Estudante_Id { get; set; }
        public int Estudante_RA { get; set; }
    }
}
