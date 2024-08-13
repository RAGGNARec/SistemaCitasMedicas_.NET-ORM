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
    public class ConsultorioControlador
    {
        private readonly ConsultorioServicio servicioConsultorio;

        public ConsultorioControlador()
        {
            servicioConsultorio = new ConsultorioServicio();
        }

        public IEnumerable<ConsultorioVistaModelo> ObtenerConsultorios()
        {
            var consultorioList = servicioConsultorio.ListarConsultorios();
            List<ConsultorioVistaModelo> vistaModelos = new List<ConsultorioVistaModelo>();

            foreach (Consultorios item in consultorioList)
            {
                vistaModelos.Add(new ConsultorioVistaModelo
                {
                    IdConsultorio = item.idConsultorio,
                    Ubicacion = item.ubicacion,
                    Descripcion = item.descripcion,
                    Estado = item.estado,
                });
            }
            return vistaModelos;
        }

        // Implementación para referenciar las tablas 
        public Consultorios ObtenerConsultorioPorId(int idConsultorio)
        {
            
            return servicioConsultorio.ObtenerConsultorioPorId(idConsultorio);
        }

        public bool InsertarConsultorio(ConsultorioVistaModelo consultorioView)
        {
            try
            {
                Consultorios nuevoConsultorio = new Consultorios
                {
                    ubicacion = consultorioView.Ubicacion,
                    descripcion = consultorioView.Descripcion,
                    estado = consultorioView.Estado,
                };

                servicioConsultorio.InsertarConsultorio(nuevoConsultorio);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar consultorio: " + ex.Message);
                return false;
            }
        }

        public bool ActualizarConsultorio(ConsultorioVistaModelo consultorioView)
        {
            try
            {
                Consultorios actualizarConsultorio = new Consultorios
                {
                    idConsultorio = consultorioView.IdConsultorio,
                    ubicacion = consultorioView.Ubicacion,
                    descripcion = consultorioView.Descripcion,
                    estado = consultorioView.Estado,
                };

                servicioConsultorio.ActualizarConsultorio(actualizarConsultorio);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el consultorio: " + ex.Message);
                return false;
            }
        }

        public bool EliminarConsultorio(int id)
        {
            try
            {
                servicioConsultorio.EliminarConsultorio(id);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el consultorio: " + ex.Message);
                return false;
            }
        }
    }
}
