
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using API.Helpers;
namespace API.Controllers;
[ApiVersion("1.1")]
[ApiVersion("1.0")]


public class ClienteController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public ClienteController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpPost("Add")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClienteDto>> Add(ClienteDto genero)
    {
        Cliente entity = _mapper.Map<Cliente>(genero);
        _unitOfWork.Clientes.Add(entity);
        await _unitOfWork.SaveAsync();
        return genero;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<ClienteDto>>> Paginacion([FromQuery] Params Params)
    {
        var labs = await _unitOfWork.Clientes.Paginacion(Params.PageIndex, Params.PageSize, Params.Search);
        var mapeo = _mapper.Map<List<ClienteDto>>(labs.registros);
        return new Pager<ClienteDto>(mapeo, labs.totalRegistros, Params.PageIndex, Params.PageSize, Params.Search);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClienteDto>> GetById(int id)
    {
        Cliente genero = await _unitOfWork.Clientes.GetById(id);
        return _mapper.Map<ClienteDto>(genero);
    }
    [MapToApiVersion("1.1")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteDto>>> GetAll()
    {
        IEnumerable<Cliente> generos = await _unitOfWork.Clientes.GetAll();
        return _mapper.Map<List<ClienteDto>>(generos);
    }
    [HttpDelete("Delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        Cliente? genero = await _unitOfWork.Clientes.GetById(id);
        if (genero == null)
        {
            return BadRequest();
        }
        _unitOfWork.Clientes.Remove(genero);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}