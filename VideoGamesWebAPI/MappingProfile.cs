using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGames.Domain.DTO;
using VideoGamesWebAPI.Models;

namespace VideoGamesWebAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GenreDto, GenreViewModel>().ReverseMap();
            CreateMap<VideoGameDto, VideoGameViewModel>().ReverseMap();
        }
    }
}
