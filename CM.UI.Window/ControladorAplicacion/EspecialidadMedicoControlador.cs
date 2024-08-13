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
    public class EspecialidadMedicoControlador
    {
        private readonly EspecialidadMedicoServicio servicioEspecialidadMedico;

        public EspecialidadMedicoControlador()
        {
            servicioEspecialidadMedico = new EspecialidadMedicoServicio();
        }

        public IEnumerable<EspecialidadMedicoVistaModelo> ObtenerEspecialidadMedico()
        {
            var especialidadList = servicioEspecialidadMedico.listarEspecialidadMedico();
            List<EspecialidadMedicoVistaModelo> vistaModelos = new List<EspecialidadMedicoVistaModelo>();

            foreach (EspecialidadMedicos item in especialidadList)
            {
                vistaModelos.Add(new EspecialidadMedicoVistaModelo
                {
                    IdMedicoEspecialidad = item.idMedicoEspecialidad,
                    IdEspecialidad = item.idEspecialidad,
                    IdMedico = item.idMedico,
                });
            }
            return vistaModelos;
        }

        public bool InsertarEspecialidadMedico(EspecialidadMedicoVistaModelo especialidadView)
        {
            try
            {
                EspecialidadMedicos nuevoEspecialidadMedico = new EspecialidadMedicos
                {
                    idMedico = especialidadView.IdMedico,
                    idEspecialidad = especialidadView.IdEspecialidad,
                };

                servicioEspecialidadMedico.insertarEspecialidadMedico(nuevoEspecialidadMedico);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar especialidad Medico: " + ex.Message);
                return false;
            }
        }

        public bool ActualizarEspecialidadMedico(EspecialidadMedicoVistaModelo especialidadView)
        {
            try
            {
                EspecialidadMedicos actualizarEspecialidadMedico = new EspecialidadMedicos
                {
                    idMedicoEspecialidad = especialidadView.IdMedicoEspecialidad,
                    idMedico = especialidadView.IdMedico,
                    idEspecialidad = especialidadView.IdEspecialidad,
                };

                servicioEspecialidadMedico.actualizarEspecialidadMedico(actualizarEspecialidadMedico);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el especialidad: " + ex.Message);
                return false;
            }
        }

        public bool EliminarEspecialidadMedico(int id)
        {
            try
            {
                servicioEspecialidadMedico.eliminarEspecialidadMedico(id);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el especialidad: " + ex.Message);
                return false;
            }
        }
    }
}

