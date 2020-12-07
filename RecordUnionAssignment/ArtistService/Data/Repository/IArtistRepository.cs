using ArtistService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ArtistService.Data.Repository
{
    public interface IArtistRepository : IRepository<Artist>
    {
        Task<Artist> GetArtistAsync(Artist request, CancellationToken cancellationToken);
    }
}
