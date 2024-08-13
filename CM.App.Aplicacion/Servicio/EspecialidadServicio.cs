using CM.Dominio.Modelo.Abstracciones;
using CM.Dominio.Modelo.Entidades;
using CM.InfraAccesoDatos.Repositorio.Implementaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.App.Aplicacion.Servicio
{
    public class EspecialidadServicio
    {
        readonly IEspecialidadRepositorio especialidadRepositorio;
        public EspecialidadServicio()
        {
            especialidadRepositorio = new EspecialidadRepositorioImpl();
        }


        public Especialidades ObtenerEspecialidadPorId(int idEspecialidad)
        {
            try
            {
                return especialidadRepositorio.GetById(idEspecialidad);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la especialdiad por ID en el servicio.", ex);
            }
        }


        public void insertarEspecialidad(Especialidades nuevoespecialidad)
        {
            try
            {
                especialidadRepositorio.Add(nuevoespecialidad);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo insertar registro,", ex);
            }

        }
        /*CREAMOS LA CLASE ACTUALIZAR LLAMAMOS AL MODIFY*/
        public void actualizarEspecialidad(Especialidades actualizarEspecialidads)
        {
            try
            {
                especialidadRepositorio.Modify(actualizarEspecialidads);//Modify es la herencia del que creamos para actualizar
            }

            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo actualizar el registro,", ex);
            }
        }


        /*CREAMOS LA CLASE LISTAR TODO LLAMANDO AL IEnumerable*/
        public IEnumerable<Especialidades> ListarEspecialidad()
        {
            try
            {
                return especialidadRepositorio.GetAll();//GetAll es la herencia del que vamos a listar
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo listar el registro,", ex);
            }
        }


        /*CREAMOS LA CLASE ELIMINAR LLAMANDO A LA Remove PERO SERA BORRADO LOGICO*/
        public void eliminarEspecialidad(int id)
        {
            try
            {
                especialidadRepositorio.Delete(id);//Delete es la herenia de que vamos a eliminar
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo eliminar el registro,", ex);
            }
        }
    }
}
