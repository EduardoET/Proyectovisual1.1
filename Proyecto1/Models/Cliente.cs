namespace Proyecto1.Models
{
    public class Cliente: Entidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; }
        public string Tipo { get; set; }

    }
}
