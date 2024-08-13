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
    public class EspecialidadControlador
    {
        private readonly EspecialidadServicio servicioEspecialidad;

        public EspecialidadControlador()
        {
            servicioEspecialidad = new EspecialidadServicio();
        }

        public IEnumerable<EspecialidadVistaModelo> ObtenerEspecialidad()
        {
            var especialidadList = servicioEspecialidad.ListarEspecialidad();
            List<EspecialidadVistaModelo> vistaModelos = new List<EspecialidadVistaModelo>();

            foreach (Especialidades item in especialidadList)
            {
                vistaModelos.Add(new EspecialidadVistaModelo
                {
                    IdEspecialidad = item.idEspecialidad,
                    Nombre = item.nombre,
                    Descripcion = item.descripcion,
                    Estado = item.estado,
                });
            }
            return vistaModelos;
        }

        public Especialidades ObtenerEspecialidadPorId(int idEspecialidad)
        {
            // Implementación para obtener el consultorio por su ID utilizando el servicioConsultorio
            return servicioEspecialidad.ObtenerEspecialidadPorId(idEspecialidad);
        }


        public bool InsertarEspecialidad(EspecialidadVistaModelo especialidadView)
        {
            try
            {
                Especialidades nuevoEspecialidad = new Especialidades
                {
                    nombre = especialidadView.Nombre,
                    descripcion = especialidadView.Descripcion,
                    estado = especialidadView.Estado,
                };

                servicioEspecialidad.insertarEspecialidad(nuevoEspecialidad);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar especialidad: " + ex.Message);
                return false;
            }
        }

        public bool ActualizarEspecialidad(EspecialidadVistaModelo especialidadView)
        {
            try
            {
                Especialidades actualizarEspecialidad = new Especialidades
                {
                    idEspecialidad = especialidadView.IdEspecialidad,
                    nombre = especialidadView.Nombre,
                    descripcion = especialidadView.Descripcion,
                    estado = especialidadView.Estado,
                };

                servicioEspecialidad.actualizarEspecialidad(actualizarEspecialidad);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el especialidad: " + ex.Message);
                return false;
            }
        }

        public bool EliminarEspecialidad(int id)
        {
            try
            {
                servicioEspecialidad.eliminarEspecialidad(id);
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

