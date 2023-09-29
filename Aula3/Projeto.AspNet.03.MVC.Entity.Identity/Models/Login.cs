using System.ComponentModel.DataAnnotations;

namespace Projeto.AspNet._03.MVC.Entity.Identity.Models
{
    // esta classe assume o "papel" de ser um elemento lógico que opere como um "conjunto de props credenciais"
    public class Login
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        public string ReturnUrl { get; set; }
        // por padrao, o asp net core vai adotar uma URL para o acesso 
    }
}
