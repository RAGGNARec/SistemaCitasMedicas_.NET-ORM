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
    public class EspecialidadMedicoServicio
    {
        readonly IEspecialidadMedicoRepositorio especialidadMedicoRepositorio;
        public EspecialidadMedicoServicio()
        {
            especialidadMedicoRepositorio = new EspecialidadMedicoRepositorioImpl();
        }

        public void insertarEspecialidadMedico(EspecialidadMedicos nuevoespecialidadMedico)
        {
            try
            {
                especialidadMedicoRepositorio.Add(nuevoespecialidadMedico);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo insertar registro,", ex);
            }

        }
        /*CREAMOS LA CLASE ACTUALIZAR LLAMAMOS AL MODIFY*/
        public void actualizarEspecialidadMedico(EspecialidadMedicos actualizarEspecialidadMedicos)
        {
            try
            {
                especialidadMedicoRepositorio.Modify(actualizarEspecialidadMedicos);//Modify es la herencia del que creamos para actualizar
            }

            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo actualizar el registro,", ex);
            }
        }


        /*CREAMOS LA CLASE LISTAR TODO LLAMANDO AL IEnumerable*/
        public IEnumerable<EspecialidadMedicos> listarEspecialidadMedico()
        {
            try
            {
                return especialidadMedicoRepositorio.GetAll();//GetAll es la herencia del que vamos a listar
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo listar el registro,", ex);
            }
        }


        /*CREAMOS LA CLASE ELIMINAR LLAMANDO A LA Remove PERO SERA BORRADO LOGICO*/
        public void eliminarEspecialidadMedico(int id)
        {
            try
            {
                especialidadMedicoRepositorio.Delete(id);//Delete es la herenia de que vamos a eliminar
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo eliminar el registro,", ex);
            }
        }
    }
}
