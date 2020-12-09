using Artist.ApiRepository;
using Artist.Data.Database;
using Artist.Domain;
using Artist.Extensions;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Artist.Service.Services
{
    public class CreateArtistService : ICreateArtistService
    {
        private readonly IMediator _mediator;

        public CreateArtistService(IMediator mediator)
        {
            _mediator = mediator;
        }


        
        public async Task<Domain.Artist> CreateArtistThroughName(Domain.Artist request, Client client)
        {
            SpotifyApi spotifyApi = new SpotifyApi(client);
            SpotifyUri spotifyUri = new SpotifyUri();
            Domain.Artist artist = new Domain.Artist();
            try
            {


                var uri = spotifyUri.GetArtistUri(request);
                artist = await spotifyApi.GetArtist(request, uri);

                

            }
            catch (Exception ex)
            {
                // log an error message here
                Debug.WriteLine(ex.Message);
            }

            return artist;
        }
    }
}

