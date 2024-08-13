using CM.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Dominio.Modelo.Abstracciones
{
    /*Método Específico: Este método no está definido en IBaseRepositorio, sino que se agrega específicamente en IPacienteRepositorio.
Propósito: Define un método para buscar un paciente por su número de cédula (ci).
Tipo de Retorno: Devuelve un objeto Paciente, que es la entidad específica que se está manipulando en este repositorio.*/
    public interface IPacienteRepositorio : IBaseRepositorio<Pacientes>

    {
        Pacientes buscarPorNombre(string nombre);
    }
}