using Microsoft.AspNetCore.Mvc;
using Proyecto1.Data;
using Proyecto1.Models;
using System.Collections.Generic;
using System.Linq;
namespace Proyecto1.Controllers
{
    public class FacturaController : Controller
    {
        private readonly DBEmpresa DB;
        public FacturaController(DBEmpresa db)
        {
            DB = db;
        }
        //METODOS PARA VISTA 
        //LISTA DE ITEMS

        [HttpGet]
        public IActionResult Index(string nombre = "", int paginaActual = 1)
        {
            int registrosPorPagina = 4;

            IEnumerable<Factura> ListaFactura
                = DB.Factura
                .Where(fac => string.IsNullOrEmpty(nombre) || fac.Tipo == nombre)
                .OrderBy(cre => cre.Id)
                .Skip((paginaActual - 1) * registrosPorPagina) //saltar los primeros (p-1)*n registros
                .Take(registrosPorPagina);              //tomar los siguientes n registros;
            int totalDeRegistros = DB.Credito.Count();

            var modeloConPaginacion = new Paginacion
            {
                entidades = ListaFactura,
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
        public IActionResult Create(Factura factura)
        {
            DB.Factura.Add(factura);
            DB.SaveChanges();

            return RedirectToAction("Index");
        }
        //Editar un Item 
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Factura factura = DB.Factura.Find(Id);
            return View(factura);
        }
        [HttpPost]
        public IActionResult Edit(Factura factura)
        {
            DB.Factura.Update(factura);
            DB.SaveChanges();

            return RedirectToAction("Index");
        }
        //Borrar Item
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Factura factura = DB.Factura.Find(Id);
            return View(factura);
        }
        [HttpPost]
        public IActionResult Delete(Factura factura)
        {
            DB.Factura.Remove(factura);
            DB.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
