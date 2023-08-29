using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Projeto.AspNet._03.MVC.Entity.Identity.Models;

namespace Projeto.AspNet._03.MVC.Entity.Identity.Controllers
{
    //este controller será responsavel pela modalidade de autenticação/autorização
    //de usuarios para acessar a area restrita da aplicação
    [Authorize] // este atributo faz com que todas as estruturas de instruções relacionadas a esta classe se tornem inacessiveis por instruções sem autorização de acesso

    // Significa que: qualquer estrutura lógica que não faz parte desta classe não pode fazer acesso a nada que, aqui, está descrito. 
    public class AccountController : Controller
    {

        // 1º movimento; configuração do controller da estrutura de login
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager; // este 2º objeto referencial nada mais é do que um "gerenciador" de recursos de acesso à areas restritas de uma aplicação
        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous] //este atributo//annotation ele permite o acesso a estas funcionalidades - descritas na action abaixo
        public IActionResult Login(string returnUrl)
        {
            // praticar a instancia direta do model login para gerar um objeto do qual se faça uso 
            // e acessar suas props

            Login login = new Login();

            login.ReturnUrl = returnUrl;

            return View(login);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login logar)
        {
            if (ModelState.IsValid)
            {
                AppUser consulta = await _userManager.FindByEmailAsync(logar.Email);

                if (consulta != null) 
                {
                    await _signInManager.SignOutAsync();

                    // fazer o uso da classe embarcada SignInResult para operar com um
                    // resultado do processo de autenticação de usuario
                    Microsoft.AspNetCore.Identity.SignInResult resultado
                    = await _signInManager.PasswordSignInAsync(consulta, logar.Password, false, false);

                    if (resultado.Succeeded)
                    {
                        // abaixo, está indicada a area restritra da aplicação,
                        // será uma action descrita no home controller com uma view respectiva 
                        return Redirect(logar.ReturnUrl ?? "/Home/Private");
                    }
                }
            }

            ModelState.AddModelError(nameof(logar.Email), "sua autenticação falhou.");
            return View(logar);
        }

        // 4º Passo: definir uma nova action, para que o usuario, uma vez logado, possa sair da area restrita
        // e ser redirecionado para uma area publica

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();


            return RedirectToAction("Index", "Home");
        }
    }
}
