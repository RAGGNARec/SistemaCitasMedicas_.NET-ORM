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
    public class MedicoServicio
    {
        readonly IMedicoRepositorio medicoRepositorio;
        public MedicoServicio()
        {
            medicoRepositorio = new MedicoRepositorioImpl();
        }


        public Medicos ObtenerMedicoPorId(int idMedico)
        {
            try
            {
                return medicoRepositorio.GetById(idMedico);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el medico por ID en el servicio.", ex);
            }
        }


        public void insertarMedico(Medicos nuevomedico)
        {
            try
            {
                medicoRepositorio.Add(nuevomedico);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo insertar registro,", ex);
            }

        }
        /*CREAMOS LA CLASE ACTUALIZAR LLAMAMOS AL MODIFY*/
        public void actualizarMedico(Medicos actualizarMedicos)
        {
            try
            {
                medicoRepositorio.Modify(actualizarMedicos);//Modify es la herencia del que creamos para actualizar
            }

            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo actualizar el registro,", ex);
            }
        }


        /*CREAMOS LA CLASE LISTAR TODO LLAMANDO AL IEnumerable*/
        public IEnumerable<Medicos> ListarMedico()
        {
            try
            {
                return medicoRepositorio.GetAll();//GetAll es la herencia del que vamos a listar
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo listar el registro,", ex);
            }
        }


        /*CREAMOS LA CLASE ELIMINAR LLAMANDO A LA Remove PERO SERA BORRADO LOGICO*/
        public void eliminarMedico(int id)
        {
            try
            {
                medicoRepositorio.Delete(id);//Delete es la herenia de que vamos a eliminar
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo eliminar el registro,", ex);
            }
        }
    }
}
