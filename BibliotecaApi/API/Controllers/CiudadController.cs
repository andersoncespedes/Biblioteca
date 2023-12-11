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
public class CiudadController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public CiudadController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpPost("Add")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CiudadDto>> Add(CiudadDto genero)
    {
        Ciudad entity = _mapper.Map<Ciudad>(genero);
        _unitOfWork.Ciudades.Add(entity);
        await _unitOfWork.SaveAsync();
        return genero;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<CiudadDto>>> Paginacion([FromQuery] Params Params)
    {
        var labs = await _unitOfWork.Ciudades.Paginacion(Params.PageIndex, Params.PageSize, Params.Search);
        var mapeo = _mapper.Map<List<CiudadDto>>(labs.registros);
        return new Pager<CiudadDto>(mapeo, labs.totalRegistros, Params.PageIndex, Params.PageSize, Params.Search);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CiudadDto>> GetById(int id)
    {
        Ciudad genero = await _unitOfWork.Ciudades.GetById(id);
        return _mapper.Map<CiudadDto>(genero);
    }
    [MapToApiVersion("1.1")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CiudadDto>>> GetAll()
    {
        IEnumerable<Ciudad> generos = await _unitOfWork.Ciudades.GetAll();
        return _mapper.Map<List<CiudadDto>>(generos);
    }
    [HttpDelete("Delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        Ciudad? genero = await _unitOfWork.Ciudades.GetById(id);
        if (genero == null)
        {
            return BadRequest();
        }
        _unitOfWork.Ciudades.Remove(genero);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}