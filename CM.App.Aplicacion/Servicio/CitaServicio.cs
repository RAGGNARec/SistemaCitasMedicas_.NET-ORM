using CM.Dominio.Modelo.Abstracciones;
using CM.Dominio.Modelo.Entidades;
using CM.InfraAccesoDatos.Repositorio.Implementaciones;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.App.Aplicacion.Servicio
{
    public class CitaServicio
    {
        readonly ICitaRepositorio citaRepositorio;
        public CitaServicio()
        {
            citaRepositorio = new CitaRepositorioImpl();
        }

        public void insertarCita(Citas nuevocita)
        {
            try
            {
                citaRepositorio.Add(nuevocita);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo insertar registro,", ex);
            }

        }
        /*CREAMOS LA CLASE ACTUALIZAR LLAMAMOS AL MODIFY*/
        public void actualizarCita(Citas actualizarCitas)
        {
            try
            {
                citaRepositorio.Modify(actualizarCitas);//Modify es la herencia del que creamos para actualizar
            }

            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo actualizar el registro,", ex);
            }
        }


        /*CREAMOS LA CLASE LISTAR TODO LLAMANDO AL IEnumerable*/
        public IEnumerable<Citas> ListarCita()
        {
            try
            {
                return citaRepositorio.GetAll();//GetAll es la herencia del que vamos a listar
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo listar el registro,", ex);
            }
        }


        /*CREAMOS LA CLASE ELIMINAR LLAMANDO A LA Remove PERO SERA BORRADO LOGICO*/
        public void eliminarCitas(int id)
        {
            try
            {
                citaRepositorio.Delete(id);//Delete es la herenia de que vamos a eliminar
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo eliminar el registro,", ex);
            }
        }
    }
}
