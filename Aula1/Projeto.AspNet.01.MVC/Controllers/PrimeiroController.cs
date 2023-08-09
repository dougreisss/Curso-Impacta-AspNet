using Microsoft.AspNetCore.Mvc;
using Projeto.AspNet._01.MVC.Models;

namespace Projeto.AspNet._01.MVC.Controllers
{
    // praticando o mecanismo de herança com a classe pai/superclasse controller
    // é neste momento que a classe criada - PrimeiroController
    // assume o "papel" de controladora do fluxos de dados 
    public class PrimeiroController : Controller
    {
        // o que esta classe/controller vai controlar?

        /*
            R: Controla o fluxo de dados da aplicação. (é o dado que tem uma origem;
            chega em outro determinado "pedaço" da aplicação e ainda tem o seu "percurso" 
            desenhado para que o trajeto seja claro e preciso.) 
            Este controle é exercido da seguinte forma: 
            será descrito um método que quando for chamado terá de exibir os dados em tela.  
        */

        // agora para exemplificar a resposta dado acima, será implementado um método que,
        // quando for chamado, retorna uma  string

        //public string Index() // método comum dentro de uma classe
        //{
        //    // por ser diferente de void, é necessario estabelecer
        //    // uma expressão de retorno para este método
        //    return "Olá mundão Asp.Net";
        //}

       // neste passo, será implementado um novo método;
       // este método será definido com a interface IActionResult
       // este é um método/action de forma explicita.
       // por ser assim é necessário declarar que ele deve retornar
       // o resultado das operações de dados numa View

        //public IActionResult Ola() 
        //{
        //    // definir uma prop que recebe um valor qualquer e,
        //    // posteriomente, este valor deverá vinculado à view para que seja exibido
        //    ViewBag.Message = "To começando a sacar como a coisa funciona!";
        //    return View();
        //}

        // definir uma nova action para que seja possivel estabelecer comunicação entre model view e controler
        public IActionResult Credenciais()
        {
            // movimento 1: estabelecer neste momento a "comunicação" entre model e controller 
            // ao praticar a instancia da classe model perfil 

            Perfil infos = new Perfil();

            // movimento 2: fazer o uso do objeto infos para acessar os atributos da classe model - perfil

            infos.Nome = "Douglas";
            infos.Idade = 20;
            infos.Endereco = "Rua maria do carmo";

            // movimento 3: definir a expressao de retorno da action 

            return View(infos);
        }
    }
}
