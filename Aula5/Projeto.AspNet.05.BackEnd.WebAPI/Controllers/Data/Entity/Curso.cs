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
        public int CursoId { get; set; }
        public string? CursoNome { get; set; }
        public double CursoMensalidade { get; set; }
        [ForeignKey("EstudanteId")]
        public int EstudanteId { get; set; }
        public int EstudanteRA { get; set; }
        // indicar a exisitencia da relaçao entre entities Estudante e Curso da seguinte forma é necessario definiir,
        // aqui uma prop que tem como data type a entity Estudante
        public Estudante? Estudante { get; set; }
    }
}
