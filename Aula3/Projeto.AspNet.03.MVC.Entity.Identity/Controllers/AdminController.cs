using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Projeto.AspNet._03.MVC.Entity.Identity.Models;

namespace Projeto.AspNet._03.MVC.Entity.Identity.Controllers
{
    // Definir o papel deste controller
    // será responsavel pelas operações CRUD do "cadastro" de dados do usuario
    // pratica do mecanismo de herança com a superclasse controller
    public class AdminController : Controller
    {
        // 1º movimento: definição de elementos referencias e
        // pratica de injeção de dependecia para as operações com os dados

        // 1º passo: definir uma prop - private - para criar um elemento lógico referencial. 
        // Neste momento, é importante criar este elemento para que seja usado no auxilio na manipulação de dados da base
        // com as quais o controller vai "lidar". Para a definição deste elemento, será usado uma classe embarcada UserManager<>
        // oferece recursos para operações com dados de usuario (essa classe tem origem no AspNetCore)

        private UserManager<AppUser> _userManager;

        // 2º passo: definir uma prop - private - para criar um elemento lógico referencial.
        // Servirá como referência para a recuperação/leitura da senha/password em estrutura Hash

        private IPasswordHasher<AppUser> _passwordHasher;

        // 3º passo: será a definição da injeção de dependencia. Para este contexto, serão usados as props de referencia
        // - a partir do construtor da classe

        public AdminController(
            UserManager<AppUser> userManager,
            IPasswordHasher<AppUser> passwordHasher)
        {
            // aqui, as props private serão acessadas e, à elas, atribuido valores,
            // referente ao parametros do construtor
            _userManager = userManager;
            _passwordHasher = passwordHasher;
        }

        // 2º movimento: criação das actions - definição das operações CRUD
        // C - create (criar), R - Read (Leitura), U - Update (Alteração/Atualização), D - Delete (exclusão)
        // AppUser: representação da table - aqui, na aplicação, do DB.
        // Neste contexto de relação entre AppUser e o model User
        // - a representação da table será responsavel por receber do model User os dados necessarios para as manipulações
        // e posteriomente, os processos de autenticação/autorização de acesso a area restrita
        // User: é o model que estabelece as "regras/formato" pelos quais os dados serão operados.

        // 1º OP CRUD - Read - action que será responsavel pela recuperação acesso e exibição de todos os dados armazenados na base
        public IActionResult Index() // está é uma action sincrona
        {
            // o que esta action vai retornar?
            return View(_userManager.Users);
            // R: o elemento lógico Users(método get) que foi acima
            // referenciado, por ser um método get - implicito. Dessa forma
            // é possivel recuperar os dados da base. é um metodo exclusivo da classe UserManager
        }

        // 2º OP CRUD - Create: action será responsavel pela inserção de dados na base.
        //public IActionResult Create() 
        //{
        //    return View();
        //}

        // esta é uma nova forma de definir uma action que tratará como resultado a mesma situação indicada na action acima
        public ViewResult Create() => View();

        // ... continuando a 2º OP: sobrecarga da action para que os dados possam ser obtidos e, posteriomente, armazenados;
        // definir o atributo de requisição HttpPost
        [HttpPost]
        // definir - de forma explicita - uma tarefa assincrona
        public async Task<IActionResult> Create(User registro)
        {
            // verificar se o ModelState  é valido
            if (ModelState.IsValid) // se a avaliação for TRUE
            {

                // definir um objeto - a partir do model/representação da table AppUser
                // para posteriomente, serem praticados os processos de autenticação/autorização de acesso à àrea restrita
                // além deste proposito acima é preciso entender que nessa action
                // está sendo disposto o processo de obtenção e armazenamento de dados

                AppUser user = new AppUser 
                {
                    UserName = registro.Name,
                    Email = registro.Email
                    // agora o objeto, AppUser possui valores para as duas props
                };

                // neste passo, será utilizado - de forma assincrona - um metodo de criação/inserção de registro na base

                //user.PasswordHash = _passwordHasher.HashPassword(user, registro.Password ?? ""); // maneira formal de passar um hash

                IdentityResult resultInsert = await _userManager.CreateAsync(user, registro.Password ?? ""); // aqui está o conjunto de dados com as 3 props definidas no model User

                // é necessario, agora, aninhar um novo if() {} - para que os recursos embarcados de sucesso possam indicar o resultado da operação
                if (resultInsert.Succeeded) 
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    // estabelecer um loop para investigar/iterar sobre eventuais erros que possam ter ocorrido

                    foreach (IdentityError identityError in resultInsert.Errors)
                    {
                        ModelState.AddModelError("", identityError.Description);
                    }
                }
            }

            return View(registro);
        }
    }
}
