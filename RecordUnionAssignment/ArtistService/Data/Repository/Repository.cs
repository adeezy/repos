using ArtistService.Data.Database;
using ArtistService.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ArtistService.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly ArtistContext ArtistContext;

        public Repository(ArtistContext artistContext)
        {
            ArtistContext = artistContext;
        }
        public IEnumerable<TEntity> GetArtist()
        {
            try
            {
                
                return ArtistContext.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't get entities {ex.Message}");
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity is null");
            }

            try
            {
                await ArtistContext.AddAsync(entity);
                await ArtistContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} not saved {ex.Message}");
            }
        }
    }
}
