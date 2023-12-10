using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles;
public class MappingProfile : Profile
{
    public MappingProfile(){
        CreateMap<Author, AuthorDto>().ReverseMap();
        CreateMap<Editorial, EditorialDto>().ReverseMap();
        CreateMap<Genero, GeneroDto>().ReverseMap();
        CreateMap<LibroDto, Libro>()
        .ReverseMap();
    }
}