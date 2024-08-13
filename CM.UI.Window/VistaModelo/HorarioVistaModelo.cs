using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.UI.Window.VistaModelo
{
    public class HorarioVistaModelo
    {
        public int IdHorario { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<System.TimeSpan> HoraInicio { get; set; }
        public Nullable<System.TimeSpan> HoraFin { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> Estado { get; set; }
    }
}
