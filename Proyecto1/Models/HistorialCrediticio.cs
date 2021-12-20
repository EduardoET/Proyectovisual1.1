namespace Proyecto1.Models
{
    public class HistorialCrediticio: Entidad
    {
        public int Id { get; set; }
        public int Puntaje { get; set; }
        public int DeudasActivas { get; set; }
        public int DeudasVencidas { get; set; }
    }
}
