using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Dominio.Modelo.Abstracciones
{
    public interface IBaseRepositorio<TEntity> where TEntity : class
    {
        /*Este método se utiliza para agregar una nueva entidad (TEntity) al repositorio.*/
        void Add(TEntity entity);
        /*Elimina una entidad del repositorio basándose en su identificador único (id).*/
        void Delete(int id);
        /* Actualiza una entidad existente en el repositorio con los datos de la entidad proporcionada.*/
        void Modify(TEntity entity);
        /*Recupera todas las entidades del tipo TEntity almacenadas en el repositorio.*/
        IEnumerable<TEntity> GetAll();
        /*Recupera una entidad específica del repositorio basada en su identificador único (id).*/
        TEntity GetById(int id);

    }
}
