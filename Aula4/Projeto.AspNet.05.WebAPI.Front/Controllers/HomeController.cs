using Microsoft.AspNetCore.Mvc;
using Projeto.AspNet._05.WebAPI.Front.Models;
using System.Diagnostics;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Text;

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

       public ViewResult AddReserva() => View();

       [HttpPost]
       public async Task<IActionResult> AddReserva(Reserva insercaoRegistro)
       {
            var urlAPI = "http://localhost:2033/api/Reservas";

            Reserva reservaRecebida = new Reserva();

            using (var reqHttp = new HttpClient())
            {
                StringContent conteudo = new StringContent(JsonConvert.SerializeObject(insercaoRegistro), Encoding.UTF8, "application/json");

                using (var requisicao = await reqHttp.PostAsync(urlAPI, conteudo))
                {
                    string apiResposta = await requisicao.Content.ReadAsStringAsync();

                    reservaRecebida = JsonConvert.DeserializeObject<Reserva>(apiResposta);
                }
            }

            return View(reservaRecebida);
       }

       public async Task<IActionResult> UpdateReserva(int id)
       {
            var urlAPI = "http://localhost:2033/api/Reservas";

            Reserva dadosObitidosBase = new Reserva();

            using (var reqHttp = new HttpClient()) 
            {
                using (var requisicao = await reqHttp.GetAsync($"{urlAPI}/{id}"))
                {
                    string apiResposta = await requisicao.Content.ReadAsStringAsync();

                    dadosObitidosBase = JsonConvert.DeserializeObject<Reserva>(apiResposta);
                }
            }

            return View(dadosObitidosBase);
       }

        [HttpPost]

        public async Task<IActionResult> UpdateReserva(Reserva reserva)
        {
            var urlAPI = "http://localhost:2033/api/Reservas";

            Reserva reservaAtualizada = new Reserva();

            using (var reqHttp = new HttpClient())
            {
                var alterandoDados = new MultipartFormDataContent();

                alterandoDados.Add(new StringContent(reserva.Id.ToString()), "Id");
                alterandoDados.Add(new StringContent(reserva.Nome), "Nome");
                alterandoDados.Add(new StringContent(reserva.Sobrenome), "Sobrenome");
                alterandoDados.Add(new StringContent(reserva.PontoA), "PontoA");
                alterandoDados.Add(new StringContent(reserva.PontoB), "PontoB");
                alterandoDados.Add(new StringContent(reserva.Endereco), "Endereco");
                alterandoDados.Add(new StringContent(reserva.CheckIn.ToString()), "CheckIn");
                alterandoDados.Add(new StringContent(reserva.CheckOut.ToString()), "CheckOut");

                using (var requisicao = await reqHttp.PutAsync(urlAPI, alterandoDados))
                {
                    string apiResposta = await requisicao.Content.ReadAsStringAsync();

                    ViewBag.Result = "Success";

                    reservaAtualizada = JsonConvert.DeserializeObject<Reserva>(apiResposta);
                }
            }

            return View(reservaAtualizada);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteReserva(int IdReserva)
        {
            var urlAPI = "http://localhost:2033/api/Reservas";

            using (var reqHttp = new HttpClient())
            {
                using (var requisicao = await reqHttp.DeleteAsync($"{urlAPI}/{IdReserva}"))
                {
                    string apiResposta = await requisicao.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }


    }
}