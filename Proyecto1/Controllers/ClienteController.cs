using Microsoft.AspNetCore.Mvc;
using Proyecto1.Data;
using Proyecto1.Models;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto1.Controllers
{
    public class ClienteController : Controller
    {
        private readonly DBEmpresa DB;
        public ClienteController(DBEmpresa db)
        {
            DB = db;
        }
        //METODOS PARA VISTA 
        //LISTA DE ITEMS

        [HttpGet]
        public IActionResult Index(string nombre="", int paginaActual = 1)
        {

            int registrosPorPagina = 4;


            IEnumerable<Cliente> ListaCliente = 
                DB.Cliente
                .Where(cli => string.IsNullOrEmpty(nombre) || cli.Nombre == nombre)
                .OrderBy(cli => cli.Id)
                .Skip((paginaActual-1) * registrosPorPagina) //saltar los primeros (p-1)*n registros
                .Take(registrosPorPagina);               //tomar los siguientes n registros

            int totalDeRegistros = DB.Cliente.Count();

            var modeloConPaginacion = new Paginacion
            {
                entidades = ListaCliente,
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
        public IActionResult Create(Cliente cliente)
        {
            DB.Cliente.Add(cliente);
            DB.SaveChanges();

            return RedirectToAction("Index");
        }
        //Editar un Item 
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Cliente cliente = DB.Cliente.Find(Id);
            return View(cliente);
        }
        [HttpPost]
        public IActionResult Edit(Cliente cliente)
        {
            DB.Cliente.Update(cliente);
            DB.SaveChanges();

            return RedirectToAction("Index");
        }
        //Borrar Item
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Cliente cliente = DB.Cliente.Find(Id);
            return View(cliente);
        }
        [HttpPost]
        public IActionResult Delete(Cliente cliente)
        {
            DB.Cliente.Remove(cliente);
            DB.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}