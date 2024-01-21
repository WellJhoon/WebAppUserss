namespace WebAppUserss.Models
{
    public class GeneralDatos
    {
        public int Id { get; set; }
        public required string ProyectName { get; set; }
        public  DateTime FechaCreacion { get; set; }

        public required string owner { get; set; }
        public int MienbrosCantidad  { get; set; }

    }
}
