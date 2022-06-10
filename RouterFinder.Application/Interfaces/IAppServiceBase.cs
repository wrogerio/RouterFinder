using System;
using System.Collections.Generic;
using System.Linq;
using RouterFinder.Application.DTO;

namespace RouterFinder.Application.Interfaces
{
    public interface IAppServiceBase<TEntity> where TEntity : class
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