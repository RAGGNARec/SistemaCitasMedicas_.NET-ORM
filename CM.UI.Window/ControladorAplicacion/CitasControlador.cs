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
    public class CitasControlador
    {
        private readonly CitaServicio servicioCitas;

        public CitasControlador()
        {
            servicioCitas = new CitaServicio();
        }

        public IEnumerable<CitasVistaModelo> ObtenerCitas()
        {
            var consultorioList = servicioCitas.ListarCita();
            List<CitasVistaModelo> vistaModelos = new List<CitasVistaModelo>();

            foreach (Citas item in consultorioList)
            {
                vistaModelos.Add(new CitasVistaModelo
                {
                    IdCita = item.idCita,
                    IdPaciente = item.idPaciente,
                    IdHorarioMedico = item.idHorarioMedico,
                    Descripcion = item.descripcion,
                    EstadoCita = item.estadoCita,
                    FechaRegistro = item.fechaRegistro,
                    HoraCita = item.horaCita,
                    Estado = item.estado

                });
            }
            return vistaModelos;
        }


        public bool InsertarCitas(CitasVistaModelo citaView)
        {
            try
            {
                Citas nuevoCitas = new Citas
                {
                    idCita = citaView.IdCita,
                    fechaRegistro = citaView.FechaRegistro,
                    descripcion = citaView.Descripcion,
                    estado = citaView.Estado,
                    estadoCita = citaView.EstadoCita,
                    idPaciente = citaView.IdPaciente,
                    idHorarioMedico = citaView.IdHorarioMedico,
                    horaCita = citaView.HoraCita,
                };

                servicioCitas.insertarCita(nuevoCitas);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar cita: " + ex.Message);
                return false;
            }
        }

        public bool ActualizarCitas(CitasVistaModelo citaView)
        {
            try
            {
                Citas actualizarCitas = new Citas
                {
                    idCita = citaView.IdCita,
                    fechaRegistro = citaView.FechaRegistro,
                    descripcion = citaView.Descripcion,
                    estado = citaView.Estado,
                    estadoCita = citaView.EstadoCita,
                    idPaciente = citaView.IdPaciente,
                    idHorarioMedico = citaView.IdHorarioMedico,
                    horaCita = citaView.HoraCita,
                };

                servicioCitas.actualizarCita(actualizarCitas);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el cita: " + ex.Message);
                return false;
            }
        }

        public bool EliminarCitas(int id)
        {
            try
            {
                servicioCitas.eliminarCitas(id);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el cita: " + ex.Message);
                return false;
            }
        }
    }
}
