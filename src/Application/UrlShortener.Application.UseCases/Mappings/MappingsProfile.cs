﻿using AutoMapper;
using UrlShortener.Application.UseCases.Commands;
using UrlShortener.Application.UseCases.DTOs;
using UrlShortener.Application.UseCases.Queries;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Application.UseCases.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<CreateShortUrlCommand, ShortenedUrl>().ReverseMap();
            CreateMap<ShortenedUrl, CreateShortUrlResponseDTO>().ReverseMap();
            CreateMap<LongUrlResponseDTO, ShortenedUrl>().ReverseMap();
        }
    }
}
