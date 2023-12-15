using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistence.Data;
using API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using Domain.Entities;
using Application.UnitOfWork;
using Domain.Interface;

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class LibroController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public LibroController (IUnitOfWork unitOfWork, IMapper map){
        _unitOfWork = unitOfWork;
        _mapper = map;
    }
    [HttpPost("AddLibro")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LibroDto>> AddBook(LibroDto libro){
        Libro entity = _mapper.Map<Libro>(libro);
        _unitOfWork.Libros.Add(entity);
        await _unitOfWork.SaveAsync();
        return libro;
    }
    [HttpPost("addPrestamo")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PrestamoDto>>> PrestarLibro(IEnumerable<PrestamoDto> prestamos){
        IEnumerable<Prestamo> prestamo = _mapper.Map<List<Prestamo>>(prestamos);
        await _unitOfWork.Libros.AddPrestamo(prestamo);
        await _unitOfWork.SaveAsync();
        return Ok(prestamos);
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<LibroDatDto>>> Paginacion([FromQuery] Params Params)
    {
        var labs = await _unitOfWork.Libros.Paginacion(Params.PageIndex, Params.PageSize, Params.Search);
        var mapeo = _mapper.Map<List<LibroDatDto>>(labs.registros);
        return new Pager<LibroDatDto>(mapeo, labs.totalRegistros, Params.PageIndex, Params.PageSize, Params.Search);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LibroDatDto>> GetById(int id){
        Libro libro = await _unitOfWork.Libros.GetById(id);
        return _mapper.Map<LibroDatDto>(libro);
    }
    [MapToApiVersion("1.1")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<LibroDatDto>>> GetAll(){
        IEnumerable<Libro> libro = await _unitOfWork.Libros.GetAll();
        return _mapper.Map<List<LibroDatDto>>(libro);
    }
    [HttpDelete("Delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id){
        Libro ? libro = await _unitOfWork.Libros.GetById(id);
        if(libro == null){
            return BadRequest();
        }
        _unitOfWork.Libros.Remove(libro);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }



}