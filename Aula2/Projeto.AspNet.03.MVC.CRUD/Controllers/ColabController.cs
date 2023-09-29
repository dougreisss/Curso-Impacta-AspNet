using Microsoft.AspNetCore.Mvc;
using Projeto.AspNet._03.MVC.CRUD.Models;
using System.Linq;

namespace Projeto.AspNet._03.MVC.CRUD.Controllers
{
    // este é o "coração" do projeto/aplicação. Aqui,
    // serão implementadas as operações com os dados acessos a partir da estrutura
    // de armazenamento e posteriomente, manipulados na view. 
    // Esta classe assume o "papel" de controller porque está em prática o mecanismo de herança com a classe "Controller"
    public class ColabController : Controller
    {
        public IActionResult Index()
        { 
            return View(Repository.TodosOsColabs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] 
        public IActionResult Create(Colab registroColab)
        {
            
            if (ModelState.IsValid)
            {
                Repository.Inserir(registroColab);
                return View("Agradecimento", registroColab);
            }

            return View();
        }

        public IActionResult Update(string Identificador)
        {
            Colab consulta = Repository.TodosOsColabs.Where(
                (e) => e.Nome == Identificador).First();

            return View(consulta);
        }

        [HttpPost]
        public IActionResult Update(string Identificador, Colab registroAlteradoCol)
        {
            if (ModelState.IsValid) 
            {
                Repository.TodosOsColabs
                    .Where((e) => e.Nome == Identificador)
                    .First().Idade = registroAlteradoCol.Idade;

                Repository.TodosOsColabs
                    .Where((e) => e.Nome == Identificador)
                    .First().Salario = registroAlteradoCol.Salario;

                Repository.TodosOsColabs
     .              Where((e) => e.Nome == Identificador)
                    .First().Departamento = registroAlteradoCol.Departamento;

                Repository.TodosOsColabs
                    .Where((e) => e.Nome == Identificador)
                    .First().Genero = registroAlteradoCol.Genero;

                Repository.TodosOsColabs
                 .Where((e) => e.Nome == Identificador)
                 .First().Nome = registroAlteradoCol.Nome;

                // Uma vez que esta tarefa está finalizada - tarefa de alteração de registro
                // Será possivel, o usuario ser redirecionado para a a view de listagem de dados

                return RedirectToAction("Index");
            }

            return View();
        }

        // 4º passo: definir a action de exclusão de um registro. Para ser excluido,
        // o registro precisa ser devidamente identificado

        [HttpPost]
        public IActionResult Delete(string Identificador)
        {
            Colab consulta = Repository.TodosOsColabs.Where(
                (e) => e.Nome == Identificador).First();

            Repository.Excluir(consulta);

            return RedirectToAction("Index");
        }
        
    }
}
