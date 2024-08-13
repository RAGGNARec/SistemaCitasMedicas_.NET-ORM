using CM.App.Aplicacion.Servicio;
using CM.Dominio.Modelo.Entidades;
using CM.UI.Window.VistaModelo;
using CM.UI.Windows.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.UI.Window.ControladorAplicacion
{
    public class MedicoControlador
    {
        private readonly MedicoServicio servicioMedico;

        public MedicoControlador()
        {
            servicioMedico = new MedicoServicio();
        }

        // Implementación para referenciar las tablas 
        public Medicos ObtenerMedicoPorId(int idMedico)
        {

            return servicioMedico.ObtenerMedicoPorId(idMedico);
        }

        public IEnumerable<MedicoVistaModelo> ObtenerMedicos()
        {
            var medicoList = servicioMedico.ListarMedico();
            List<MedicoVistaModelo> vistaModelos = new List<MedicoVistaModelo>();

            foreach (Medicos item in medicoList)
            {
                vistaModelos.Add(new MedicoVistaModelo
                {
                    IdMedico = item.idMedico,
                    IdConsultorio = item.idConsultorio,
                    Nombre = item.nombre,
                    Apellido = item.apellido,
                    Direccion = item.direccion,
                    Telefono = item.telefono,
                    Correo = item.correo,
                    CodigoMedico = item.codigoMedico,
                    Estado = item.estado,
                });
            }
            return vistaModelos;
        }

        public bool InsertarMedico(MedicoVistaModelo medicoView)
        {
            try
            {
                Medicos nuevoMedico = new Medicos
                {
                    idConsultorio = medicoView.IdConsultorio,
                    nombre = medicoView.Nombre,
                    apellido = medicoView.Apellido,
                    direccion = medicoView.Direccion,
                    telefono = medicoView.Telefono,
                    correo = medicoView.Correo,
                    codigoMedico = medicoView.CodigoMedico,
                    estado = medicoView.Estado,
                };

                servicioMedico.insertarMedico(nuevoMedico);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar medico: " + ex.Message);
                return false;
            }
        }

        public bool ActualizarMedico(MedicoVistaModelo medicoView)
        {
            try
            {
                Medicos actualizarMedico = new Medicos
                {
                    idMedico = medicoView.IdMedico,
                    idConsultorio = medicoView.IdConsultorio,
                    nombre = medicoView.Nombre,
                    apellido = medicoView.Apellido,
                    direccion = medicoView.Direccion,
                    telefono = medicoView.Telefono,
                    correo = medicoView.Correo,
                    codigoMedico = medicoView.CodigoMedico,
                    estado = medicoView.Estado,
                };

                servicioMedico.actualizarMedico(actualizarMedico);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el medico: " + ex.Message);
                return false;
            }
        }

        public bool EliminarMedico(int id)
        {
            try
            {
                servicioMedico.eliminarMedico(id);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el medico: " + ex.Message);
                return false;
            }
        }
    }
}
