using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Artist.Data.Repository
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        public IEnumerable<TEntity> GetArtist();

        Task<TEntity> AddAsync(TEntity entity);

    }
}
