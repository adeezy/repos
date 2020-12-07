using ArtistService.Data.Repository;
using ArtistService.Domain;
using ArtistService.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ArtistService.Service.Query
{
    public class GetArtistQueryHandler : IRequestHandler<GetArtistQuery, Artist>
    {
        ModifyString modifyString = new ModifyString();
    
        private readonly IArtistRepository _artistRepository;

        public GetArtistQueryHandler(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public async Task<Artist> Handle(GetArtistQuery request, CancellationToken cancellationToken)
        {
            var artist = new Artist();
            artist.ArtistName = modifyString.stringModifier(request.Request);
            return await _artistRepository.GetArtistAsync(artist, cancellationToken);
        }
    }
}
