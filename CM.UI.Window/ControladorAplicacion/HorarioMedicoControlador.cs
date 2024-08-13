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
    public class HorarioMedicoControlador
    {
        private readonly HorarioMedicoServicio servicioHorarioMedico;

        //CODIGO PARA RELACIONAR LAS TABLAS
        public HorarioMedicoControlador()
        {
            servicioHorarioMedico = new HorarioMedicoServicio();
        }


        // Implementación para referenciar las tablas 
        public HorarioMedicos ObtenerHorarioPorId(int idHorario)
        {

            return servicioHorarioMedico.ObtenerHorarioPorId(idHorario);
        }

        public IEnumerable<HorarioMedicoVistaModelo> ObtenerHorarioMedico()
        {
            var horarioMedicoList = servicioHorarioMedico.listarHorarioMedico();
            List<HorarioMedicoVistaModelo> vistaModelos = new List<HorarioMedicoVistaModelo>();

            foreach (HorarioMedicos item in horarioMedicoList)
            {
                vistaModelos.Add(new HorarioMedicoVistaModelo
                {
                    IdHorarioMedico = item.idHorarioMedico,
                    IdMedico = item.idMedico,
                    IdHorario = item.idHorario,
                    
                });
            }
            return vistaModelos;
        }

        public bool InsertarHorarioMedico(HorarioMedicoVistaModelo horarioMedicoView)
        {
            try
            {
                HorarioMedicos nuevoHorarioMedico = new HorarioMedicos
                {
                    idMedico = horarioMedicoView.IdMedico,
                    idHorario = horarioMedicoView.IdHorario

                };

                servicioHorarioMedico.insertarHorarioMedico(nuevoHorarioMedico);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar horarioMedico: " + ex.Message);
                return false;
            }
        }

        public bool ActualizarHorarioMedico(HorarioMedicoVistaModelo horarioMedicoView)
        {
            try
            {
                HorarioMedicos actualizarHorarioMedico = new HorarioMedicos
                {
                    idHorarioMedico = horarioMedicoView.IdHorarioMedico,
                    idMedico = horarioMedicoView.IdMedico,
                    idHorario = horarioMedicoView.IdHorario,

                };

                servicioHorarioMedico.actualizarHorarioMedico(actualizarHorarioMedico);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el horarioMedico: " + ex.Message);
                return false;
            }
        }

        public bool EliminarHorarioMedico(int id)
        {
            try
            {
                servicioHorarioMedico.eliminarHorarioMedico(id);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el horarioMedico: " + ex.Message);
                return false;
            }
        }
    }
}

