using Microsoft.AspNetCore.Mvc;
using Proyecto1.Data;
using Proyecto1.Models;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto1.Controllers
{
    public class CreditoController : Controller
    {
        private readonly DBEmpresa DB;
        public CreditoController(DBEmpresa db)
        {
            DB = db;
        }
        //METODOS PARA VISTA 
        //LISTA DE ITEMS

        [HttpGet]
        public IActionResult Index(string tipo = "", int paginaActual = 1)
        {
            int registrosPorPagina = 4;

            IEnumerable<Credito> ListaCredito 
                = DB.Credito
                .Where(cre => string.IsNullOrEmpty(tipo) || cre.Tipo == tipo)
                .OrderBy(cre => cre.Id)
                .Skip((paginaActual - 1) * registrosPorPagina) //saltar los primeros (p-1)*n registros
                .Take(registrosPorPagina);              //tomar los siguientes n registros;
            int totalDeRegistros = DB.Credito.Count();

            var modeloConPaginacion = new Paginacion
            {
                entidades = ListaCredito,
                PaginaActual = paginaActual,
                RegistrosPorPagina = registrosPorPagina,
                TotalDeRegistros = totalDeRegistros
            };

            return View(modeloConPaginacion);
        }
         
        // CREAR UN ITEM
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Credito credito)
        {
            DB.Credito.Add(credito);
            DB.SaveChanges();

            return RedirectToAction("Index");
        }
        //Editar un Item 
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Credito credito = DB.Credito.Find(Id);
            return View(credito);
        }
        [HttpPost]
        public IActionResult Edit(Credito credito)
        {
            DB.Credito.Update(credito);
            DB.SaveChanges();

            return RedirectToAction("Index");
        }
        //Borrar Item
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Credito credito = DB.Credito.Find(Id);
            return View(credito);
        }
        [HttpPost]
        public IActionResult Delete(Credito credito)
        {
            DB.Credito.Remove(credito);
            DB.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}