using System;
using System.Collections.Generic;

namespace RouterFinder.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        // insert
        void Add(TEntity obj);

        // update
        void Update(TEntity obj);

        // delete
        void Delete(TEntity obj);

        // delete by id
        void Delete(Guid id);

        // get by id
        TEntity GetById(Guid id);

        // get all
        IEnumerable<TEntity> GetAll();
    }
}