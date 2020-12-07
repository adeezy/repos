using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ArtistService.Domain;
using ArtistService.Data.Database;
using System.Security.Cryptography.X509Certificates;
using ArtistService.Service.Query;

namespace ArtistService.Data.Repository
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(ArtistContext artistContext) : base(artistContext)
        {
           
        }

        public Task<Artist> GetArtistAsync(Artist request, CancellationToken cancellationToken)
        {
            
            return ArtistContext.Artist.FirstOrDefaultAsync(_ => _.ArtistName.Replace(".", "").Replace(" ", "").ToLower() == request.ArtistName);
        }
    }
}
