using CM.App.Aplicacion.Servicio;
using CM.Dominio.Modelo.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass]
    public class UnitTestPaciente
    {
        PacienteServicio pacienteServicio = new PacienteServicio();

        [TestMethod]

        public void TestMethod1()
        {
            /*
            //INSERTAR PACIENTE 1
            Console.WriteLine("Insertar Paciente 1");
            Pacientes nuevopaciente = new Pacientes();
            nuevopaciente.nombre = "María";
            nuevopaciente.apellido = "González";
            nuevopaciente.cedula = "1728394056";
            nuevopaciente.direccion = "avenida de los Shyris";
            nuevopaciente.telefono = "0987654321";
            nuevopaciente.correo = "maria.gonzalez@gmail.com";
            nuevopaciente.estado = 1;
            nuevopaciente.fechaNacimiento = DateTime.Parse("1995-07-15");

            pacienteServicio.InsertarPaciente(nuevopaciente);


            //LISTAR PACIENTE 1 
            Console.WriteLine("Listar Paciente");
            var datosBase = pacienteServicio.ListarPaciente();

            foreach (var item in datosBase)
            {
                Console.WriteLine(item.idPaciente + " - " + item.nombre + " - " + item.apellido + " - " + item.direccion + " - " + item.cedula + " - " + item.telefono + " - " + item.correo + " - " + item.estado);
            }


            //INSERTAR PACIENTE 2
            Console.WriteLine("Insertar Paciente 2");
            Pacientes nuevopaciente2 = new Pacientes();
            nuevopaciente2.nombre = "Laura";
            nuevopaciente2.apellido = "Martínez";
            nuevopaciente2.cedula = "1789012345";
            nuevopaciente2.direccion = "Calle Los Rosales";
            nuevopaciente2.telefono = "0991234567";
            nuevopaciente2.correo = "laura.martinez@gmail.com";
            nuevopaciente2.estado = 0;
            nuevopaciente2.fechaNacimiento = DateTime.Parse("1985-06-25");
            pacienteServicio.InsertarPaciente(nuevopaciente2);

            //LISTAR PACIENTE 2
            Console.WriteLine("Listar Paciente2");
            var datosBase2 = pacienteServicio.ListarPaciente();
            foreach (var item in datosBase2)
            {
                Console.WriteLine(item.idPaciente + " - " + item.nombre + " - " + item.apellido + " - " + item.direccion + " - " + item.cedula + " - " + item.telefono + " - " + item.correo + " - " + item.estado);
            }


            //MODIFICAR PACIENTE 2 
            Console.WriteLine("Modificar paciente");
            Pacientes nuevoParaActulizar = new Pacientes();
            nuevoParaActulizar.nombre = "ACTUALIZADO Laura";
            nuevoParaActulizar.apellido = "ACTUALIZADO Martínez";
            nuevoParaActulizar.cedula = "178";
            nuevoParaActulizar.direccion = "Calle ACTUALIZADO";
            nuevoParaActulizar.telefono = "09912";
            nuevoParaActulizar.correo = "ACTUALIZADO@gmail.com";
            nuevoParaActulizar.estado = 0;
            nuevoParaActulizar.fechaNacimiento = DateTime.Parse("1985-06-25");

            nuevoParaActulizar.idPaciente = 5;
            pacienteServicio.ActualizarPaciente(nuevoParaActulizar);

            //LISTAR PACIENTE 2 ACTUALIZADO
            Console.WriteLine("Listar Paciente 2 ACTUALIZADO");
            var datosBase3 = pacienteServicio.ListarPaciente();
            foreach (var item in datosBase3)
            {
                Console.WriteLine(item.idPaciente + " - " + item.nombre + " - " + item.apellido + " - " + item.direccion + " - " + item.cedula + " - " + item.telefono + " - " + item.correo + " - " + item.estado);
            }


            //FUNCION DE BORRAR LOS DATOS
           // Console.WriteLine("Borrar Paciente");
            //pacienteServicio.EliminarPaciente(3);


            //LISTAR PACIENTE BORRADO
            Console.WriteLine("NUEVA LISTA");
            var datosBase4 = pacienteServicio.ListarPaciente();
            foreach (var item in datosBase4)
            {
                Console.WriteLine(item.idPaciente + " - " + item.nombre + " - " + item.apellido + " - " + item.direccion + " - " + item.cedula + " - " + item.telefono + " - " + item.correo + " - " + item.estado);
            }
            */


            var item = pacienteServicio.buscarPorNombre("Alison");
            Console.WriteLine(item.idPaciente + " - " + item.nombre + " - " + item.apellido + " - " + item.direccion + " - " + item.cedula + " - " + item.telefono + " - " + item.correo + " - " + item.estado);
        }
    }
}
