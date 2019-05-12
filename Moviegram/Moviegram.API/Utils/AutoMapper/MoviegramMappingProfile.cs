using AutoMapper;
using Moviegram.Data.Entities;
using Moviegram.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moviegram.API.Utils.AutoMapper
{
    public class MoviegramMappingProfile : Profile

    {
        public MoviegramMappingProfile()
        {
            CreateMap<Movie, MovieDTO>().ForMember(x => x.Times, opt => opt.Ignore());
            CreateMap<MovieDTO, Movie>().ForMember(x => x.Times, opt => opt.Ignore());
        }
    }
}
