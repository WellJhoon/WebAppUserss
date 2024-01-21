namespace WebAppUserss.Models
{
    public class ProjectDetails
    {
        public int Id { get; set; }

        public string ProyectName { get; set; }
        public string description { get; set; }
        public string ProyectDescription { get; set; }

        public string owner { get; set; }

        public int CantidadMienbros { get; set; }

        public DateTime FechaCreacion { get; set; }

        public bool FechaCierre { get; set; }

        public bool Estado { get; set; }

    }
}
