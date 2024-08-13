using System;

namespace CM.UI.Windows.VistaModelo
{
    public class PacienteVistaModelo
    {
        public int IdPaciente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public Nullable<int> Estado { get; set; }
        public DateTime? FechaNacimiento { get; set; }
    }
}
