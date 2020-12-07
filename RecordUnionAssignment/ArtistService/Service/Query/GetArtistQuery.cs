using ArtistService.Domain;
using ArtistService.Service.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtistService.Service.Query
{
    public class GetArtistQuery : IRequest<Artist>
    {
        public GetArtistQuery(Artist request)
        {
            Request = request;
        }
        public Artist Request;

    }
}
