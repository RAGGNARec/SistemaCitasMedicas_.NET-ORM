using CM.Dominio.Modelo.Abstracciones;
using CM.Dominio.Modelo.Entidades;
using CM.InfraAccesoDatos.Repositorio.Implementaciones;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace CM.App.Aplicacion.Servicio
{
    public class ConsultorioServicio
    {
        readonly IConsultorioRepositorio consultorioRepositorio;
        public ConsultorioServicio()
        {
            consultorioRepositorio = new ConsultorioRepositorioImpl();
        }


        public Consultorios ObtenerConsultorioPorId(int idConsultorio)
        {
            try
            {
                return consultorioRepositorio.GetById(idConsultorio);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el consultorio por ID en el servicio.", ex);
            }
        }



        public void InsertarConsultorio(Consultorios nuevoConsultorio)
        {
            try
            {
                consultorioRepositorio.Add(nuevoConsultorio);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo insertar el registro,", ex);
            }

        }

        public void ActualizarConsultorio(Consultorios actualizarConsultorio)
        {
            try
            {
                consultorioRepositorio.Modify(actualizarConsultorio);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo actualizar el registro,", ex);
            }
        }

        public IEnumerable<Consultorios> ListarConsultorios()
        {
            try
            {
                return consultorioRepositorio.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo listar el registro,", ex);
            }
        }

        public void EliminarConsultorio(int id)
        {
            try
            {
                consultorioRepositorio.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo eliminar el registro,", ex);
            }
        }
    }
}
