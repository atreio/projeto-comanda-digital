using ComandaDigital.Models.Base;
using System.Linq;

namespace ComandaDigital.Servicos.Base
{
    public interface ICrudRepository<T> where T : IEntity
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
