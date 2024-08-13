using CM.Dominio.Modelo.Abstracciones;
using CM.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.InfraAccesoDatos.Repositorio.Implementaciones
{
    public class PacienteRepositorioImpl : BaseRepositorioImpl<Pacientes>, IPacienteRepositorio
    {
        public Pacientes buscarPorNombre(string nombre)
        {
            try
            {
                using (var context = new DBCitasMedicasEntities())
                {
                    var resultado = from pasc in context.Pacientes
                                    where pasc.nombre == nombre
                                    select pasc;
                    return resultado.Single();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("EROR :  no se puede insertar el registro", ex);

            }
        }
    }
}
