using Artist.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Artist.Data.Repository
{
    public interface IArtistRepository : IRepository<Domain.Artist>
    {
        Task<Domain.Artist> GetArtistAsync(Domain.Artist request, CancellationToken cancellationToken);
    }
}
