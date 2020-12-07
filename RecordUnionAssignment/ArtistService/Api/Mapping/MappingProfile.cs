using ArtistService.Api.Models;
using ArtistService.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtistService.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ArtistModel, Artist>()
                .ForMember(x => x.State, opt => opt.MapFrom(src => 1));
        }
    }
}
