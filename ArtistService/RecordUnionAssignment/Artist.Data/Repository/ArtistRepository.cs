using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Artist.Domain;
using Artist.Data.Database;
using System.Security.Cryptography.X509Certificates;


namespace Artist.Data.Repository
{
    public class ArtistRepository : Repository<Domain.Artist>, IArtistRepository
    {
        public ArtistRepository(ArtistContext artistContext) : base(artistContext)
        {
           
        }

        public Task<Domain.Artist> GetArtistAsync(Domain.Artist request, CancellationToken cancellationToken)
        {
            
            return ArtistContext.Artist.FirstOrDefaultAsync(_ => _.ArtistName.Replace(".", "").Replace(" ", "").ToLower() == request.ArtistName);
        }
    }
}
