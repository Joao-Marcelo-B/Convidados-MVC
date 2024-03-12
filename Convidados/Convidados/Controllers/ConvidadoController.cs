using Convidados.Models;
using Microsoft.AspNetCore.Mvc;

namespace Convidados.Controllers
{
    public class ConvidadoController : Controller
    {
        private static List<Convidado> Convidados = new() 
        { 
            new()
            {
                Comparecimento = true,
                Nome = "João Marcelo",
                ConvidadoId = 1,
                Email = "joao@marcelo.com",
                Telefone = "35847734849"
            },
            new()
            {
                Nome = "Joao Ninguem",
                ConvidadoId=2,
                Email = "joao@ninguem.com",
                Telefone = "3767635874"
            },
            new()
            {
                ConvidadoId = 3,
                Email = "joao@alguem.com",
                Nome = "João Alguém",
                Telefone = "2763462764"
            }
        };

        public IActionResult Index()
        {
            return View(Convidados.OrderBy(x => x.ConvidadoId));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Convidado convidados)
        {
            convidados.ConvidadoId = Convidados.Select(x => x.ConvidadoId).Max() + 1;
            Convidados.Add(convidados);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(Convidados.Where(x => x.ConvidadoId == id).First());
        }

        [HttpPost]
        public IActionResult Edit(Convidado convidado)
        {
            Convidados.Remove(Convidados.Where(x => x.ConvidadoId == convidado.ConvidadoId).First());
            Convidados.Add(convidado);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            return View(Convidados.Where(x => x.ConvidadoId.Equals(id)).First());
        }

        [HttpPost]
        public IActionResult Delete(Convidado convidado)
        {
            Convidados.Remove(Convidados.Where(x => x.ConvidadoId.Equals(convidado.ConvidadoId)).First());

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(Convidados.FirstOrDefault(x => x.ConvidadoId.Equals(id)));
        }

        public IActionResult ListaPresenca()
        {
            return View(Convidados.Where(x => x.Comparecimento.Equals(true)).ToList());
        }
    }
}
