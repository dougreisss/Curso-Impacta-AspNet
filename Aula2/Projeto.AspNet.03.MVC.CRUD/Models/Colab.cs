using System.ComponentModel.DataAnnotations;

namespace Projeto.AspNet._03.MVC.CRUD.Models
{
    public class Colab
    {
        [Required(ErrorMessage = "Insira, por favor, seu nome.")]
        public string? Nome { get; set; }
        [Range(15, 99, ErrorMessage = "Informe, por favor, uma idade entre 15 e 99 anos.")]
        public int Idade { get; set; }
        [RegularExpression(@"\d+(\.\d{1, 2})?", ErrorMessage = "Valor invalido. Sugestão: insira dessa forma $ ou $.$")]
        public decimal Salario { get; set; }
        public string? Departamento { get; set; }
        [RegularExpression(@"^[FMO]+$", ErrorMessage = "Selecione ao menos um valor.")]
        public Char Genero { get; set; }
    }
}
