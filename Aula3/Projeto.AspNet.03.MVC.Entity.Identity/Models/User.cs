using System.ComponentModel.DataAnnotations;

namespace Projeto.AspNet._03.MVC.Entity.Identity.Models
{
    public class User
    {
        [Required(ErrorMessage = "Por informe seu nome. ")]
        public string? Name { get; set; }
        [Required]
        [RegularExpression("[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2, 6}$")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Por favor, insira uma senha bacana")]
        public string? Password { get; set; }
    }
}
