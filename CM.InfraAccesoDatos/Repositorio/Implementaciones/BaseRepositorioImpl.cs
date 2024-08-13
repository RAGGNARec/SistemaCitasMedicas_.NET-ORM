using CM.Dominio.Modelo.Abstracciones;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.InfraAccesoDatos.Repositorio.Implementaciones
{
    public class BaseRepositorioImpl<TEntity> : IDisposable, IBaseRepositorio<TEntity> where TEntity : class
    {
        public void Add(TEntity entity)//Método agregar
        {
            try
            {

                using (var context = new DBCitasMedicasEntities())
                {
                    context.Set<TEntity>().Add(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: No se pudo insertar registro,", ex);
            }

        }

        public void Modify(TEntity entity)//Método Modificar
        {
            try
            {
                using (var context = new DBCitasMedicasEntities())

                {
                    context.Entry(entity).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: No se pudo modificar registro,", ex);
            }


        }

        public void Delete(int id)//Método eliminar
        {
            try
            {
                using (var context = new DBCitasMedicasEntities())

                {
                    var entity = context.Set<TEntity>().Find(id);
                    context.Set<TEntity>().Remove(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: No se pudo eliminar registro,", ex);
            }

        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                using (var context = new DBCitasMedicasEntities())

                {
                    return context.Set<TEntity>().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: No se pudo listar registro,", ex);
            }
            //throw new NotImplementedException();
        }

        public TEntity GetById(int id)//Buscar por ID por PK
        {
            try
            {
                using (var context = new DBCitasMedicasEntities())

                {
                    return context.Set<TEntity>().Find(id);

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: No se pudo recuperar registro,", ex);
            }
            //throw new NotImplementedException();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
