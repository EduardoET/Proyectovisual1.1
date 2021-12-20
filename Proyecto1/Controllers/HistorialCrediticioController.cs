using Microsoft.AspNetCore.Mvc;
using Proyecto1.Data;
using Proyecto1.Models;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto1.Controllers
{
    public class HistorialCrediticioController : Controller
    {
        private readonly DBEmpresa DB;
        public HistorialCrediticioController(DBEmpresa db)
        {
            DB = db;
        }
        //METODOS PARA VISTA 
        //LISTA DE ITEMS

        [HttpGet]
        public IActionResult Index( int paginaActual = 1)
        {
            int registrosPorPagina = 4;
            IEnumerable<HistorialCrediticio> ListaHistorialCrediticio 
                = DB.HistorialCrediticio
                
                .OrderBy(hiscre => hiscre.Id)
                .Skip((paginaActual - 1) * registrosPorPagina) //saltar los primeros (p-1)*n registros
                .Take(registrosPorPagina);              //tomar los siguientes n registros;
            int totalDeRegistros = DB.HistorialCrediticio.Count(); 

            var modeloConPaginacion = new Paginacion
            {
                entidades = ListaHistorialCrediticio,
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
        public IActionResult Create(HistorialCrediticio historialcrediticio)
        {
            DB.HistorialCrediticio.Add(historialcrediticio);
            DB.SaveChanges();

            return RedirectToAction("Index");
        }

        //Editar un Item 
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            HistorialCrediticio historialcrediticio = DB.HistorialCrediticio.Find(Id);
            return View(historialcrediticio);
        }
        [HttpPost]
        public IActionResult Edit(HistorialCrediticio historialcrediticio)
        {
            DB.HistorialCrediticio.Update(historialcrediticio);
            DB.SaveChanges();

            return RedirectToAction("Index");
        }
        //Borrar Item
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            HistorialCrediticio historialcrediticio = DB.HistorialCrediticio.Find(Id);
            return View(historialcrediticio);
        }
        [HttpPost]
        public IActionResult Delete(HistorialCrediticio historialcrediticio)
        {
            DB.HistorialCrediticio.Remove(historialcrediticio);
            DB.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}