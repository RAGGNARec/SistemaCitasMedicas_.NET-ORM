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
    public class HorarioServicio
    {
        readonly IHorarioRepositorio horarioRepositorio;
        public HorarioServicio()
        {
            horarioRepositorio = new HorarioRepositorioImpl();
        }


        public Horarios ObtenerHorarioPorId(int idHorario)
        {
            try
            {
                return horarioRepositorio.GetById(idHorario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el horario por ID en el servicio.", ex);
            }
        }

        public void insertarHorario(Horarios nuevohorario)
        {
            try
            {
                horarioRepositorio.Add(nuevohorario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo insertar registro,", ex);
            }

        }
        /*CREAMOS LA CLASE ACTUALIZAR LLAMAMOS AL MODIFY*/
        public void actualizarHorario(Horarios actualizarHorarios)
        {
            try
            {
                horarioRepositorio.Modify(actualizarHorarios);//Modify es la herencia del que creamos para actualizar
            }

            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo actualizar el registro,", ex);
            }
        }


        /*CREAMOS LA CLASE LISTAR TODO LLAMANDO AL IEnumerable*/
        public IEnumerable<Horarios> ListarHorarios()
        {
            try
            {
                return horarioRepositorio.GetAll();//GetAll es la herencia del que vamos a listar
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo listar el registro,", ex);
            }
        }


        /*CREAMOS LA CLASE ELIMINAR LLAMANDO A LA Remove PERO SERA BORRADO LOGICO*/
        public void eliminarHorario(int id)
        {
            try
            {
                horarioRepositorio.Delete(id);//Delete es la herenia de que vamos a eliminar
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo eliminar el registro,", ex);
            }
        }
    }
}
