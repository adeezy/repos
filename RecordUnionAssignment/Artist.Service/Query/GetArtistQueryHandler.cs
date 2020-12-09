using Artist.Data.Repository;
using Artist.Domain;
using Artist.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Artist.Service.Query
{
    public class GetArtistQueryHandler : IRequestHandler<GetArtistQuery, Domain.Artist>
    {
        ModifyString modifyString = new ModifyString();
    
        private readonly IArtistRepository _artistRepository;

        public GetArtistQueryHandler(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public async Task<Domain.Artist> Handle(GetArtistQuery request, CancellationToken cancellationToken)
        {
            var artist = new Domain.Artist();
            artist.ArtistName = modifyString.stringModifier(request.Request);
            return await _artistRepository.GetArtistAsync(artist, cancellationToken);
        }
    }
}
