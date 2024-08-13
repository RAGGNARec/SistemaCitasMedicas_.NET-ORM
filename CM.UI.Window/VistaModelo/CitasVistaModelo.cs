using CM.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.UI.Window.VistaModelo
{
    public class CitasVistaModelo
    {
        public int IdCita { get; set; }
        public Nullable<System.DateTime> FechaRegistro { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> Estado { get; set; }
        public string EstadoCita { get; set; }
        public int IdPaciente { get; set; }
        public int IdHorarioMedico { get; set; }
        public Nullable<System.TimeSpan> HoraCita { get; set; }

        public virtual HorarioMedicos HorarioMedicos { get; set; }
        public virtual Pacientes Pacientes { get; set; }
    }
}
