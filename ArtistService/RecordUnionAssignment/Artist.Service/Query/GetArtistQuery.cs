using Artist.Domain;
using Artist.Service.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Artist.Service.Query
{
    public class GetArtistQuery : IRequest<Domain.Artist>
    {
        public GetArtistQuery(Domain.Artist request)
        {
            Request = request;
        }
        public Domain.Artist Request;

    }
}
