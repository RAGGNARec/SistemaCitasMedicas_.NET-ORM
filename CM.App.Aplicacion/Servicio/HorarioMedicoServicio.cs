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
    public class HorarioMedicoServicio
    {
        readonly IHorarioMedicoRepositorio horarioMedicoRepositorio;
        public HorarioMedicoServicio()
        {
            horarioMedicoRepositorio = new HorarioMedicoRepositorioImpl();
        }

        public HorarioMedicos ObtenerHorarioPorId(int idHorario)

        {
            try
            {
                return horarioMedicoRepositorio.GetById(idHorario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el horario medico por ID en el servicio.", ex);
            }
        }



        public void insertarHorarioMedico(HorarioMedicos nuevohorarioMedico)
        {
            try
            {
                horarioMedicoRepositorio.Add(nuevohorarioMedico);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo insertar registro,", ex);
            }

        }
        /*CREAMOS LA CLASE ACTUALIZAR LLAMAMOS AL MODIFY*/
        public void actualizarHorarioMedico(HorarioMedicos actualizarHorarioMedicos)
        {
            try
            {
                horarioMedicoRepositorio.Modify(actualizarHorarioMedicos);//Modify es la herencia del que creamos para actualizar
            }

            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo actualizar el registro,", ex);
            }
        }


        /*CREAMOS LA CLASE LISTAR TODO LLAMANDO AL IEnumerable*/
        public IEnumerable<HorarioMedicos> listarHorarioMedico()
        {
            try
            {
                return horarioMedicoRepositorio.GetAll();//GetAll es la herencia del que vamos a listar
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo listar el registro,", ex);
            }
        }


        /*CREAMOS LA CLASE ELIMINAR LLAMANDO A LA Remove PERO SERA BORRADO LOGICO*/
        public void eliminarHorarioMedico(int id)
        {
            try
            {
                horarioMedicoRepositorio.Delete(id);//Delete es la herenia de que vamos a eliminar
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo eliminar el registro,", ex);
            }
        }
    }
}
