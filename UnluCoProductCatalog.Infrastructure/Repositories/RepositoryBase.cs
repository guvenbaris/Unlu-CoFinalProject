using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using UnluCoProductCatalog.Application.Interfaces.Repositories;
using UnluCoProductCatalog.Domain.Entities;
using UnluCoProductCatalog.Infrastructure.Contexts;

namespace UnluCoProductCatalog.Infrastructure.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(ProductCatalogDbContext context) => _dbSet = context.Set<TEntity>();

        public IEnumerable<TEntity> GetAll() => _dbSet.ToList().Where(p => p.IsDeleted == false).ToList();

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter) => _dbSet.Where(filter).ToList().Where(p=>p.IsDeleted == false);

        public TEntity GetById(int id) => _dbSet.Where(p => p.IsDeleted == false).SingleOrDefault(x => x.Id == id);

        public void Create(TEntity entity) => _dbSet.Add(entity);

        public void Delete(TEntity entity) => _dbSet.Remove(entity);

        public void Update(TEntity entity) => _dbSet.Update(entity);
    }
}
