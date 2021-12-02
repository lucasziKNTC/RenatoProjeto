using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PROJETO01.Dados.EntityFramework;
using PROJETO01.Modelos;

namespace PROJETO01.Controllers
{
    public class CidadeController : Controller
    {
        public IActionResult Adicionar()
        {
            var db = new Contexto();
            ViewBag.Estados = db.Estado.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AdicionarConfirmacao(Cidade cidade)
        {
            return RedirectToAction("Listar");
        }
    }
}