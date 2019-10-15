using ComandaDigital.Models.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ComandaDigital.Servicos.Base
{
    public class CrudRepository<T> : ICrudRepository<T> where T : IEntity
    {
        protected readonly ComandaDigitalContext dbContext;

        public CrudRepository(ComandaDigitalContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(T entity)
        {
            dbContext.Set<T>().Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            dbContext.Set<T>().Remove(entity);
            dbContext.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return dbContext.Set<T>().AsTracking();
        }

        public T GetById(int id)
        {
            return dbContext.Set<T>()
                .AsTracking()
                .FirstOrDefault(e => e.Id == id);
        }

        public void Update(T entity)
        {
            dbContext.Set<T>().Update(entity);
            dbContext.SaveChanges();
        }
    }
}
