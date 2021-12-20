using Microsoft.AspNetCore.Mvc;
using Proyecto1.Data;
using Proyecto1.Models;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto1.Controllers
{
    public class HistorialCrediticioInternoController1 : Controller
    {
        private readonly DBEmpresa DB;
        public HistorialCrediticioInternoController1(DBEmpresa db)
        {
            DB = db;
        }
        [HttpGet]
        public IActionResult Index(int paginaActual = 1)
        {
            int registrosPorPagina = 4;
            IEnumerable<HistorialCrediticioInterno> ListaHistorialCrediticioInterno 
                = DB.HistorialCrediticioInterno.OrderBy(hisint => hisint.Id)
                .Skip((paginaActual - 1) * registrosPorPagina) //saltar los primeros (p-1)*n registros
                .Take(registrosPorPagina);              //tomar los siguientes n registros;
            int totalDeRegistros = DB.HistorialCrediticioInterno.Count();

            var modeloConPaginacion = new Paginacion
            {
                entidades = ListaHistorialCrediticioInterno,
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
        public IActionResult Create(HistorialCrediticioInterno historialcrediticiointerno)
        {
            DB.HistorialCrediticioInterno.Add(historialcrediticiointerno);
            DB.SaveChanges();

            return RedirectToAction("Index");
        }
        //Editar un Item 
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            HistorialCrediticioInterno historialcrediticiointerno = DB.HistorialCrediticioInterno.Find(Id);
            return View(historialcrediticiointerno);
        }
        [HttpPost]
        public IActionResult Edit(HistorialCrediticioInterno historialcrediticiointerno)
        {
            DB.HistorialCrediticioInterno.Update(historialcrediticiointerno);
            DB.SaveChanges();

            return RedirectToAction("Index");
        }
        //Borrar Item
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            HistorialCrediticioInterno historialcrediticiointerno = DB.HistorialCrediticioInterno.Find(Id);
            return View(historialcrediticiointerno);
        }
        [HttpPost]
        public IActionResult Delete(HistorialCrediticioInterno historialcrediticiointerno)
        {
            DB.HistorialCrediticioInterno.Remove(historialcrediticiointerno);
            DB.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}