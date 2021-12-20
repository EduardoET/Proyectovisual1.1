using System.Collections.Generic;

namespace Proyecto1.Models
{
    public class Paginacion
    {
        
        public IEnumerable<Entidad> entidades { get; set; }
        public int PaginaActual { get; set; }
        public int TotalDeRegistros { get; set; }
        public int RegistrosPorPagina { get; set; }
    }
}

