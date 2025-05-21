﻿using Domain.Models;

namespace Domain.Contracts
{
    public interface IUnitOfWork
    {
        Task<int> SavaChangesAsync();

        IGenericRepository<TEntity , TKey> GetRepository<TEntity , TKey>()
            where TEntity : BaseEntity <TKey>;
        IGenericRepository<TEntity,int> GetRepository<TEntity>()
            where TEntity : BaseEntity<int>;
    }
}
