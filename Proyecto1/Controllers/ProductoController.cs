using Microsoft.AspNetCore.Mvc;
using Proyecto1.Data;
using Proyecto1.Models;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto1.Controllers
{
    public class ProductoController : Controller
    {
        private readonly DBEmpresa DB;

        public ProductoController(DBEmpresa db)
        {
            DB = db;
        }
        //METODOS PARA VISTA 
        //LISTA DE ITEMS

        
        public IActionResult Index(string nombre = "", int paginaActual = 1)
        {
            int registrosPorPagina = 4;

            IEnumerable<Producto> ListaProductos 
                = DB.Producto
                .Where(pro => string.IsNullOrEmpty(nombre) || pro.Nombre == nombre)
                .OrderBy(pro => pro.Id)
                .Skip((paginaActual - 1) * registrosPorPagina) //saltar los primeros (p-1)*n registros
                .Take(registrosPorPagina);

            int totalDeRegistros = DB.Producto.Count();

            var modeloConPaginacion = new Paginacion
            {
                entidades = ListaProductos,
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
        public IActionResult Create(Producto producto)
        {
            DB.Producto.Add(producto);
            DB.SaveChanges();

            return RedirectToAction("Index");
        }

        //Editar un Item 
        [HttpGet]
        public IActionResult Edit(int Id)
        {
           Producto producto = DB.Producto.Find(Id);
            return View(producto);
        }
        [HttpPost]
        public IActionResult Edit(Producto producto)
        {
            DB.Producto.Update(producto);
            DB.SaveChanges();

            return RedirectToAction("Index");
        }
        //Borrar Item
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Producto producto = DB.Producto.Find(Id);
            return View(producto);
        }
        [HttpPost]
        public IActionResult Delete(Producto producto)
        {
            DB.Producto.Remove(producto);
            DB.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
