using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repository.Contracts
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        Task<TEntity> Add(TEntity entity);
        Task<bool> Delete(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<TEntity> FindById(TKey key);
        Task<List<TEntity>> FindByClause(Func<TEntity, bool> Selector = null);
    }
}
