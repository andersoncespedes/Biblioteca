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
public class DepartamentoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public DepartamentoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpPost("Add")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DepartamentoDto>> Add(DepartamentoDto genero)
    {
        Departamento entity = _mapper.Map<Departamento>(genero);
        _unitOfWork.Departamentos.Add(entity);
        await _unitOfWork.SaveAsync();
        return genero;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<DepartamentoDto>>> Paginacion([FromQuery] Params Params)
    {
        var labs = await _unitOfWork.Departamentos.Paginacion(Params.PageIndex, Params.PageSize, Params.Search);
        var mapeo = _mapper.Map<List<DepartamentoDto>>(labs.registros);
        return new Pager<DepartamentoDto>(mapeo, labs.totalRegistros, Params.PageIndex, Params.PageSize, Params.Search);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DepartamentoDto>> GetById(int id)
    {
        Departamento genero = await _unitOfWork.Departamentos.GetById(id);
        return _mapper.Map<DepartamentoDto>(genero);
    }
    [MapToApiVersion("1.1")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DepartamentoDto>>> GetAll()
    {
        IEnumerable<Departamento> generos = await _unitOfWork.Departamentos.GetAll();
        return _mapper.Map<List<DepartamentoDto>>(generos);
    }
    [HttpDelete("Delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        Departamento? genero = await _unitOfWork.Departamentos.GetById(id);
        if (genero == null)
        {
            return BadRequest();
        }
        _unitOfWork.Departamentos.Remove(genero);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}