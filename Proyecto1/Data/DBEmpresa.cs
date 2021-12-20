using Microsoft.EntityFrameworkCore;
using Proyecto1.Models;

namespace Proyecto1.Data
{
    public class DBEmpresa: DbContext 
    {
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Credito> Credito { get; set; }
        public DbSet<Factura> Factura { get; set; }
        public DbSet<HistorialCrediticio> HistorialCrediticio { get; set; }
        public DbSet<HistorialCrediticioInterno> HistorialCrediticioInterno { get; set; }

        public DBEmpresa(DbContextOptions<DBEmpresa> options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Producto>().HasData(
                new Producto { Id = 1, Nombre="Refrigeradora", Marca="Mabe", Precio=850.00M, Stock= 25 },
                new Producto { Id = 2, Nombre = "Refrigeradora", Marca = "GE", Precio = 1610.00M, Stock = 10 },
                new Producto { Id = 3, Nombre = "Refrigeradora", Marca = "Electrolux", Precio = 720.00M, Stock = 13 },
                new Producto { Id = 4, Nombre = "Refrigeradora", Marca = "Indurama", Precio = 850.00M, Stock = 25 },
                new Producto { Id = 5, Nombre = "Refrigeradora", Marca = "Continental", Precio = 1150.00M, Stock = 16 },
                new Producto { Id = 6, Nombre = "Cocina", Marca = "Mabe", Precio = 450.00M, Stock = 7 },
                new Producto { Id = 7, Nombre = "Cocina", Marca = "GE", Precio = 538.00M, Stock = 9 },
                new Producto { Id = 8, Nombre = "Cocina", Marca = "Electrolux", Precio = 599.00M, Stock = 11 },
                new Producto { Id = 9, Nombre = "Cocina", Marca = "Indurama", Precio = 538.00M, Stock = 9 },
                new Producto { Id = 10, Nombre = "Cocina", Marca = "Continental", Precio = 625.00M, Stock = 12 },
                new Producto { Id = 11, Nombre = "Microondas", Marca = "Mabe", Precio = 178.00M, Stock = 4 }
                );

            builder.Entity<Cliente>().HasData(
                new Cliente { Id = 1, Nombre= "Eduardo", Apellido="Taco", Email="eduardo@gmail.com", Telefono= 0983121592, Tipo="Nuevo"},
                new Cliente { Id = 2, Nombre = "Leslie", Apellido = "Betancourt", Email = "leslie@gmail.com", Telefono = 0983123456, Tipo = "habitual" },
                new Cliente { Id = 3, Nombre = "Lisseth", Apellido = "Muñoz", Email = "liss@gmail.com", Telefono = 0983123456, Tipo = "Nuevo" },
                new Cliente { Id = 4, Nombre = "Belen", Apellido = "Vlarezo", Email = "belen@gmail.com", Telefono = 0983121598, Tipo = "habitual" },
                new Cliente { Id = 5, Nombre = "Hugo", Apellido = "Paucar", Email = "hugo@gmail.com", Telefono = 098314567, Tipo = "Nuevo" }
                );

            builder.Entity<Credito>().HasData(
                new Credito { Id = 1, Tipo="Credito Directo", Fecha_Solicitud= "24-10-2021"},
                new Credito { Id = 2, Tipo = "Pago en dos partes", Fecha_Solicitud = "25-10-2021" },
                new Credito { Id = 3, Tipo = "Cheque", Fecha_Solicitud = "26-10-2021" },
                new Credito { Id = 4, Tipo = "Efectivo", Fecha_Solicitud = "27-10-2021" }
                );
            builder.Entity<HistorialCrediticio>().HasData(
                new HistorialCrediticio { Id = 1, Puntaje=950, DeudasActivas= 2, DeudasVencidas= 0},
                new HistorialCrediticio { Id = 2, Puntaje = 650, DeudasActivas = 1, DeudasVencidas = 1 },
                new HistorialCrediticio { Id = 3, Puntaje = 820, DeudasActivas = 3, DeudasVencidas = 0 },
                new HistorialCrediticio { Id = 4, Puntaje = 439, DeudasActivas = 4, DeudasVencidas = 4 },
                new HistorialCrediticio { Id = 5, Puntaje = 919, DeudasActivas = 2, DeudasVencidas = 0}
                );
            builder.Entity<HistorialCrediticioInterno>().HasData(
                new HistorialCrediticioInterno { Id = 1, Puntaje= 98, DeudasActivas=1, DeudasVencidas=0 },
                new HistorialCrediticioInterno { Id = 2, Puntaje = 89, DeudasActivas = 2, DeudasVencidas = 1 },
                new HistorialCrediticioInterno { Id = 3, Puntaje = 76, DeudasActivas = 1, DeudasVencidas = 2 },
                new HistorialCrediticioInterno { Id = 4, Puntaje = 56, DeudasActivas = 0, DeudasVencidas = 5 },
                new HistorialCrediticioInterno { Id = 5, Puntaje = 86, DeudasActivas = 1, DeudasVencidas = 0 }
                );
            builder.Entity<Factura>().HasData(
                new Factura { Id = 1, Nombre = "Eduardo",Email = "eduardo@gmail.com", Telefono = 0983121592, Tipo = "Nuevo", Estado = "Entregado" },
                new Factura{ Id = 2, Nombre = "Leslie",  Email = "leslie@gmail.com", Telefono = 0983123456, Tipo = "habitual", Estado = "Pendiente de Entrega" },
                new Factura { Id = 3, Nombre = "Lisseth",  Email = "liss@gmail.com", Telefono = 0983123456, Tipo = "Nuevo", Estado = "Entregado" },
                new Factura { Id = 4, Nombre = "Belen",  Email = "belen@gmail.com", Telefono = 0983121598, Tipo = "habitual",Estado = "Pendiente de Entrega" },
                new Factura { Id = 5, Nombre = "Hugo", Email = "hugo@gmail.com", Telefono = 098314567, Tipo = "Nuevo", Estado= "Entregado" }
                );
        }
       
    }
}
