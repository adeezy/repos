using Artist.Api.Models;
using Artist.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Artist.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ArtistModel, Domain.Artist>()
                .ForMember(x => x.State, opt => opt.MapFrom(src => 1));
        }
    }
}
