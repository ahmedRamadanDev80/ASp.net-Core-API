﻿using AutoMapper;
using learnApi.Models;
using learnApi.Models.Dto;

namespace learnApi
{
    public class MappingConfig :Profile
    {
        public MappingConfig()
        {
            CreateMap<Villa, VillaDTO>();
            CreateMap<VillaDTO, Villa>();
            CreateMap<Villa, VillaCreateDTO>().ReverseMap();
            CreateMap<Villa, VillaUpdateDTO>().ReverseMap();
        }
    }
}
