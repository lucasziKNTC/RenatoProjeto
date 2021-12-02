using Microsoft.AspNetCore.Mvc;
using PROJETO01.Dados.EntityFramework;
using PROJETO01.Modelos;
using PROJETO01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJETO01.Controllers
{
    public class EstadoController : Controller
    {
        public IActionResult Index(string uf, string estado)
        {
            var objeto = new Estado();
            objeto.UF = uf;
            objeto.Nome = estado;

            return View(objeto);
        }

        [HttpGet]
        public IActionResult Adicionar()
        {
            return View();
        }

        public IActionResult AdicionarConfirmacao(Estado estado)
        {
            var db = new Contexto();

            var obj = db.Estado.FirstOrDefault(f => f.UF == estado.UF);

            if (obj == null)
            {
                db.Estado.Add(estado);
            }
            else
            {
                obj.Nome = estado.Nome;
                db.Estado.Update(obj);
            }
            
            db.SaveChanges();

            return RedirectToAction("Listar");
        }

        [HttpGet]
        public IActionResult Editar(string uf)
        {
            var db = new Contexto();
            var estado = db.Estado.First(item => item.UF == uf);
            return View("Adicionar", estado);
        }

        public IActionResult Listar() {

            //SELECT * FROM Estado
            var listaDeEstados = new Contexto().Estado.ToList();

            return View(listaDeEstados);
        }

        public IActionResult Excluir(string uf)
        {
            var db = new Contexto();
            var estado = db.Estado.First(f => f.UF == uf);
            db.Estado.Remove(estado);
            db.SaveChanges();

            return RedirectToAction("Listar");
        }
    }
}
