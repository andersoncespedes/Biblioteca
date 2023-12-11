using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Entities;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using API.Helpers;
namespace API.Controllers;
[ApiVersion("1.1")]
[ApiVersion("1.0")]
public class GeneroController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public GeneroController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpPost("Add")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GeneroDto>> Add(GeneroDto genero)
    {
        Genero entity = _mapper.Map<Genero>(genero);
        _unitOfWork.Generos.Add(entity);
        await _unitOfWork.SaveAsync();
        return genero;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<GeneroDto>>> Paginacion([FromQuery] Params Params)
    {
        var labs = await _unitOfWork.Generos.Paginacion(Params.PageIndex, Params.PageSize, Params.Search);
        var mapeo = _mapper.Map<List<GeneroDto>>(labs.registros);
        return new Pager<GeneroDto>(mapeo, labs.totalRegistros, Params.PageIndex, Params.PageSize, Params.Search);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GeneroDto>> GetById(int id)
    {
        Genero genero = await _unitOfWork.Generos.GetById(id);
        return _mapper.Map<GeneroDto>(genero);
    }
    [MapToApiVersion("1.1")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<GeneroDto>>> GetAll()
    {
        IEnumerable<Genero> generos = await _unitOfWork.Generos.GetAll();
        return _mapper.Map<List<GeneroDto>>(generos);
    }
    [HttpDelete("Delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        Genero? genero = await _unitOfWork.Generos.GetById(id);
        if (genero == null)
        {
            return BadRequest();
        }
        _unitOfWork.Generos.Remove(genero);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

}