using ArtistService.Domain;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtistService.Service.Services
{
    public interface ICreateArtistService
    {
            Task<Artist> CreateArtistThroughName(Artist request, Client _appSettings);  
    }
}
