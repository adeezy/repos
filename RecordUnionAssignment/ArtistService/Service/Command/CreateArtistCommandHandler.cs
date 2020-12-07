using ArtistService.Data.Repository;
using ArtistService.Domain;
using ArtistService.Service.Services;
using MediatR;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ArtistService.Service.Command
{
    public class CreateArtistCommandHandler : IRequestHandler<CreateArtistCommand, Artist>
    {
        private readonly IArtistRepository _artistRepository;
        private readonly ICreateArtistService _createArtistService;
        private readonly Client _appSettings;

        public CreateArtistCommandHandler(IArtistRepository artistRepository, ICreateArtistService createArtistService, Client app)
        {
            _createArtistService = createArtistService;
            _artistRepository = artistRepository;
            _appSettings = app;
        }

        public async Task<Artist> Handle(CreateArtistCommand request, CancellationToken cancellationToken)
        {
            var response = _createArtistService.CreateArtistThroughName(request.Artist, _appSettings);

            var artist = new Artist();
            artist.ArtistID = response.Result.ArtistID;
            artist.ArtistName = response.Result.ArtistName;


            return await _artistRepository.AddAsync(artist);
        }
    }
}
