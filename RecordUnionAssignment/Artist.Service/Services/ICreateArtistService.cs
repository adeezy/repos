using Artist.Domain;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Artist.Service.Services
{
    public interface ICreateArtistService
    {
            Task<Domain.Artist> CreateArtistThroughName(Domain.Artist request, Client _appSettings);  
    }
}
