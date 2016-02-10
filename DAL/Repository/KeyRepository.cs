using System;
using System.Linq;
using System.Data.Entity;
using DAL.Interfaces;
using ORM;

namespace DAL
{
    public class KeyRepository<TEntity, TDALEntity, TEntityMapper> : BaseRepository<TEntity, TDALEntity, TEntityMapper>, IKeyRepository<TDALEntity>
        where TEntity : class, IORMKeyEntity, new()
        where TDALEntity : class, IDALKeyEntity, new()
        where TEntityMapper : IMapperDAL<TEntity, TDALEntity>, new()
    {
        public KeyRepository(DbContext context) : base(context) { }

        public TDALEntity GetById(Guid Id)
        {
            Func<TEntity, TDALEntity> f = (obj) => _entityMapper.ToDAL(obj);
            return _context.Set<TEntity>().AsNoTracking().Where(x => x.Id == Id).Select(f).FirstOrDefault();
        } 

    }
}