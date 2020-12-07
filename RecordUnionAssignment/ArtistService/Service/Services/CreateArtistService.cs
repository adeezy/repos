using ArtistService.ApiRepository;
using ArtistService.Data.Database;
using ArtistService.Domain;
using ArtistService.Extensions;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ArtistService.Service.Services
{
    public class CreateArtistService : ICreateArtistService
    {
        private readonly IMediator _mediator;

        public CreateArtistService(IMediator mediator)
        {
            _mediator = mediator;
        }


        
        public async Task<Artist> CreateArtistThroughName(Artist request, Client client)
        {
            SpotifyApi spotifyApi = new SpotifyApi(client);
            SpotifyUri spotifyUri = new SpotifyUri();
            Artist artist = new Artist();
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

