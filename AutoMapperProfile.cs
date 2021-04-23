using AutoMapper;
using Rpg.Dtos;
using Rpg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rpg
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character,CharacterDto>();
            CreateMap<CharacterDto, Character>();
        }
    }
}
