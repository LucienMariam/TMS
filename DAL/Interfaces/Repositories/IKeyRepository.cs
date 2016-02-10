using System;

namespace DAL.Interfaces
{
    public interface IKeyRepository<TEntity> : IRepository<TEntity>
           where TEntity : IDALKeyEntity
    {
        TEntity GetById(Guid Id);
    }
}
