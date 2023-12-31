﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);

        T? FindByCondution(Expression<Func<T, bool>> condition ,bool trackChanges);

        void Create(T entity);

        void Remove(T entity);

        void Update(T entity);
    }
}
