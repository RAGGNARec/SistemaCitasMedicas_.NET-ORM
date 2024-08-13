using CM.App.Aplicacion.Servicio;
using CM.Dominio.Modelo.Entidades;
using CM.UI.Window.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.UI.Window.ControladorAplicacion
{
    public class HorarioControlador
    {
        private readonly HorarioServicio servicioHorario;

        public HorarioControlador()
        {
            servicioHorario = new HorarioServicio();
        }

        // Implementación para referenciar las tablas 
        public Horarios ObtenerHorarioPorId(int idHorario)
        {

            return servicioHorario.ObtenerHorarioPorId(idHorario);
        }

        public IEnumerable<HorarioVistaModelo> ObtenerHorario()
        {
            var horarioList = servicioHorario.ListarHorarios();
            List<HorarioVistaModelo> vistaModelos = new List<HorarioVistaModelo>();

            foreach (Horarios item in horarioList)
            {
                vistaModelos.Add(new HorarioVistaModelo
                {
                    IdHorario = item.idHorario,
                    Fecha = item.fecha,
                    HoraInicio = item.horaInicio,
                    HoraFin = item.horaFin,
                    Descripcion = item.descripcion,
                    Estado = item.estado

                });
            }
            return vistaModelos;
        }


        public bool InsertarHorario(HorarioVistaModelo horarioView)
        {
            try
            {
                Horarios nuevoHorario = new Horarios
                {
                    idHorario = horarioView.IdHorario,
                    fecha = horarioView.Fecha,
                    horaInicio = horarioView.HoraInicio,
                    horaFin = horarioView.HoraFin,
                    descripcion = horarioView.Descripcion,
                    estado = horarioView.Estado,
                };

                servicioHorario.insertarHorario(nuevoHorario);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar horario: " + ex.Message);
                return false;
            }
        }

        public bool ActualizarHorario(HorarioVistaModelo horarioView)
        {
            try
            {
                Horarios actualizarHorario = new Horarios
                {
                    idHorario = horarioView.IdHorario,
                    fecha = horarioView.Fecha,
                    horaInicio = horarioView.HoraInicio,
                    horaFin = horarioView.HoraInicio,
                    descripcion = horarioView.Descripcion,
                    estado = horarioView.Estado,
                };

                servicioHorario.actualizarHorario(actualizarHorario);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el horario: " + ex.Message);
                return false;
            }
        }

        public bool EliminarHorario(int id)
        {
            try
            {
                servicioHorario.eliminarHorario(id);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el horario: " + ex.Message);
                return false;
            }
        }
    }
}
