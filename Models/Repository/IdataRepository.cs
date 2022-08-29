using System.Collections.Generic;

namespace HotelManagementSystem.Models.Repository
{
    public interface IdataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        void Add(TEntity entity);
        void Update(TEntity dbentity, TEntity entity);
        void Delete(TEntity entity);
    }
}
