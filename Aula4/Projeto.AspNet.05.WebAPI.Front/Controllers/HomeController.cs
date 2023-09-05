using Microsoft.AspNetCore.Mvc;
using Projeto.AspNet._05.WebAPI.Front.Models;
using System.Diagnostics;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Projeto.AspNet._05.WebAPI.Front.Controllers
{
    public class HomeController : Controller
    {
       public async Task<IActionResult> Index()
       {
            var urlAPI = "http://localhost:2033/api/Reservas";

            List<Reserva> listaReservas = new List<Reserva>();

            using (HttpClient client = new HttpClient())
            {
                using (var requisicao = await client.GetAsync(urlAPI.ToString()))
                {
                    string apiResposta = await requisicao.Content.ReadAsStringAsync();

                    listaReservas = JsonConvert.DeserializeObject<List<Reserva>>(apiResposta);
                }
            }

            return View(listaReservas);
       }

       public ViewResult GetReserva() => View();

       [HttpPost]
       public async Task<IActionResult> GetReserva(int id)
       {
            var urlAPI = "http://localhost:2033/api/Reservas";

            Reserva reserva = new Reserva();

            using (HttpClient client = new HttpClient())
            {
                using (var requisicao = await client.GetAsync($"{urlAPI}/{id}"))
                {
                    if (requisicao.StatusCode == System.Net.HttpStatusCode.OK) 
                    {
                        string apiResposta = await requisicao.Content.ReadAsStringAsync();
                        reserva = JsonConvert.DeserializeObject<Reserva>(apiResposta);
                    }
                    else 
                    {
                        ViewBag.StatusCode = requisicao.StatusCode;
                    }
                }
            }

            return View(reserva);
       }
    }
}