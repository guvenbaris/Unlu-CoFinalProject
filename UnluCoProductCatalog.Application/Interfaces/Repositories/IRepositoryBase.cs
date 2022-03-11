using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.Application.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Get(Expression<Func<T, bool>> filter);
        T GetById(int id);
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
    }

}
