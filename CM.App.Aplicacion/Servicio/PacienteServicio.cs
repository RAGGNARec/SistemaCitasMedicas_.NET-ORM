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
    public class PacienteServicio
    {
        readonly IPacienteRepositorio pacienteRepositorio;
        public PacienteServicio()
        {
            pacienteRepositorio = new PacienteRepositorioImpl();
        }

        public Pacientes ObtenerPacientePorId(int idPaciente)
        {
            try
            {
                return pacienteRepositorio.GetById(idPaciente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el paciente por ID en el servicio.", ex);
            }
        }



        public void InsertarPaciente(Pacientes nuevopaciente)
        {
            try
            {
                pacienteRepositorio.Add(nuevopaciente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo insertar registro,", ex);
            }

        }

        public IEnumerable<Pacientes> ListarPaciente()
        {
            try
            {
                return pacienteRepositorio.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo insertar registro,", ex);
            }
        }

        public void ActualizarPaciente(Pacientes actualizarPaciente)
        {
            try
            {
                pacienteRepositorio.Modify(actualizarPaciente);//Modify es la herencia del que creamos para actualizar
            }

            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo actualizar el registro,", ex);
            }
        }


        /*CREAMOS LA CLASE ELIMINAR LLAMANDO A LA Remove PERO SERA BORRADO LOGICO*/
        public void EliminarPaciente(int Id)
        {
            try
            {
                pacienteRepositorio.Delete(Id);//Delete es la herenia de que vamos a eliminar
            }
            catch (Exception ex)
            {
                throw new Exception("Error Servicio: No se pudo eliminar el registro,", ex);
            }
        }

        public Pacientes buscarPorNombre(string nombre)
        {
            try
            {
                return pacienteRepositorio.buscarPorNombre(nombre);
            }
            catch(Exception ex)
            {
                throw new Exception("Error. Servicio no se puede insertar registro", ex);
            }
        }

    }
}

