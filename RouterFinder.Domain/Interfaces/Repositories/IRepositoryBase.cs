using System;
using System.Linq;

namespace RouterFinder.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        // get all
        IQueryable<TEntity> GetAll();

        // get by id
        TEntity GetById(Guid id);

        // insert
        void Add(TEntity entity);

        // update
        void Update(TEntity entity);

        // delete
        void Delete(TEntity entity);

        // delete by id
        void Delete(Guid id);
    }
}