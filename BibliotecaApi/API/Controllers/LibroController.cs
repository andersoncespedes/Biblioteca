using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistence.Data;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using Domain.Entities;
using Application.UnitOfWork;
using Domain.Interface;

namespace API.Controllers;
public class LibroController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public LibroController (IUnitOfWork unitOfWork, IMapper map){
        _unitOfWork = unitOfWork;
        _mapper = map;
    }
    [HttpPost("AddLibro")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LibroDto>> AddBook(LibroDto libro){
        Libro entity = _mapper.Map<Libro>(libro);
        _unitOfWork.Libros.Add(entity);
        await _unitOfWork.SaveAsync();
        return libro;
    }

}