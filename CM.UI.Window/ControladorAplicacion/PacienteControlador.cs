using CM.Dominio.Modelo.Entidades;
using CM.App.Aplicacion.Servicio;
using CM.UI.Windows.VistaModelo;
using System;
using System.Collections.Generic;

namespace CM.UI.Windows.ControladorAplicacion
{
    public class PacienteControlador
    {
        private readonly PacienteServicio servicioPaciente;

        public PacienteControlador()
        {
            servicioPaciente = new PacienteServicio();
        }


        // Implementación para referenciar las tablas 
        public Pacientes ObtenerPacientePorId(int idPaciente)
        {

            return servicioPaciente.ObtenerPacientePorId(idPaciente);
        }

        public IEnumerable<PacienteVistaModelo> ObtenerPacientes()
        {
            var pacienteList = servicioPaciente.ListarPaciente();
            List<PacienteVistaModelo> vistaModelos = new List<PacienteVistaModelo>();

            foreach (Pacientes item in pacienteList)
            {
                vistaModelos.Add(new PacienteVistaModelo
                {
                    IdPaciente = item.idPaciente,
                    Nombre = item.nombre,
                    Apellido = item.apellido,
                    Cedula = item.cedula,
                    Direccion = item.direccion,
                    Telefono = item.telefono,
                    Correo = item.correo,
                    Estado = item.estado,
                    FechaNacimiento = item.fechaNacimiento
                });
            }
            return vistaModelos;
        }

        public bool InsertarPaciente(PacienteVistaModelo pacienteView)
        {
            try
            {
                Pacientes nuevoPaciente = new Pacientes
                {
                    nombre = pacienteView.Nombre,
                    apellido = pacienteView.Apellido,
                    cedula = pacienteView.Cedula,
                    direccion = pacienteView.Direccion,
                    telefono = pacienteView.Telefono,
                    correo = pacienteView.Correo,
                    estado = pacienteView.Estado,
                    fechaNacimiento = pacienteView.FechaNacimiento
                };

                servicioPaciente.InsertarPaciente(nuevoPaciente);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar paciente: " + ex.Message);
                return false;
            }
        }

        public bool ActualizarPaciente(PacienteVistaModelo pacienteView)
        {
            try
            {
                Pacientes actualizarPaciente = new Pacientes
                {
                    idPaciente = pacienteView.IdPaciente,
                    nombre = pacienteView.Nombre,
                    apellido = pacienteView.Apellido,
                    cedula = pacienteView.Cedula,
                    direccion = pacienteView.Direccion,
                    telefono = pacienteView.Telefono,
                    correo = pacienteView.Correo,
                    estado = pacienteView.Estado,
                    fechaNacimiento = pacienteView.FechaNacimiento
                };

                servicioPaciente.ActualizarPaciente(actualizarPaciente);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el paciente: " + ex.Message);
                return false;
            }
        }

        public bool EliminarPaciente(int id)
        {
            try
            {
                servicioPaciente.EliminarPaciente(id);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el paciente: " + ex.Message);
                return false;
            }
        }
    }
}
