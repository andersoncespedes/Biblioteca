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
        CreateMap<Libro, LibroDatDto>()
        .ForMember(e => e.Generos, dest => dest.MapFrom(f => f.Generos.Select(e => e.Descripcion)))
        .ReverseMap();
        CreateMap<Pais, PaisDto>()
        .ReverseMap();
        CreateMap<Departamento, DepartamentoDto>()
        .ReverseMap();
        CreateMap<Ciudad, CiudadDto>()
        .ReverseMap();
        CreateMap<Cliente, ClienteDto>()
        .ReverseMap();
        CreateMap<Prestamo, PrestamoDto>()
        .ReverseMap();
    }
}