using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RouterFinder.Domain.Interfaces.Repositories;
using RouterFinder.Infra.Context;

namespace RouterFinder.Infra.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        // get context from dependency injection
        private readonly RouterFinderContext _context;

        public RepositoryBase(RouterFinderContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        // get all entities
        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsNoTracking();
        }

        // get entity by id
        public TEntity GetById(Guid id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        // insert entity
        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        // update entity
        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        // delete entity
        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        // delete entity by id
        public void Delete(Guid id)
        {
            _context.Set<TEntity>().Remove(GetById(id));
            _context.SaveChanges();
        }
    }
}