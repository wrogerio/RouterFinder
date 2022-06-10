using System;
using System.Collections.Generic;
using RouterFinder.Domain.Interfaces.Repositories;
using RouterFinder.Domain.Interfaces.Services;

namespace RouterFinder.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        // get repository from dependency injection
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        // add new entity
        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        // get all entities
        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        // delete entity by id
        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        // get entity by id
        public TEntity GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        // delete entity
        public void Delete(TEntity obj)
        {
            _repository.Delete(obj);
        }

        // update entity
        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }
    }
}