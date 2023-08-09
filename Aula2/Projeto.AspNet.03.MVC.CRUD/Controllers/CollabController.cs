using Microsoft.AspNetCore.Mvc;

namespace Projeto.AspNet._03.MVC.CRUD.Controllers
{
    public class CollabController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
