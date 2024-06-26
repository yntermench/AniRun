using AniRun.Application.Models.FormModels;
using AniRun.Application.Models.ViewModels;
using AniRun.Domain.Aggregates;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace AniRun.Application.Mappings;

public class AnimeProfile : Profile
{
    public AnimeProfile()
    {
        CreateMap<ViewGenre, Genre>().ReverseMap();
        CreateMap<FormGenre, Genre>().ReverseMap();
        CreateMap<ViewGenre, FormGenre>().ReverseMap();
        
        CreateMap<ViewMedia, Media>().ReverseMap();
        CreateMap<FormMedia, Media>().ReverseMap();
        CreateMap<FormMedia, ViewMedia>().ReverseMap();
        
        CreateMap<ViewStudio, Studio>().ReverseMap();
        CreateMap<FormStudio, Studio>().ReverseMap();
        CreateMap<ViewStudio, FormStudio>().ReverseMap();
        
        CreateMap<ViewTitle, Title>().ReverseMap();
        CreateMap<FormTitle, Title>().ReverseMap();
        CreateMap<ViewTitle, FormTitle>().ReverseMap();
        
        CreateMap<ViewEpisode, Episode>().ReverseMap();
        CreateMap<FormEpisode, Episode>().ReverseMap();
        CreateMap<ViewEpisode, FormEpisode>().ReverseMap();
    }
}