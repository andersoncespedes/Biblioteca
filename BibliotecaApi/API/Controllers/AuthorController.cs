using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using API.Helpers;
namespace API.Controllers;
[ApiVersion("1.1")]
[ApiVersion("1.0")]
public class AuthorController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public AuthorController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpPost("Add")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AuthorDto>> Add(AuthorDto genero)
    {
        Author entity = _mapper.Map<Author>(genero);
        _unitOfWork.Authores.Add(entity);
        await _unitOfWork.SaveAsync();
        return genero;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<AuthorDto>>> Paginacion([FromQuery] Params Params)
    {
        var labs = await _unitOfWork.Authores.Paginacion(Params.PageIndex, Params.PageSize, Params.Search);
        var mapeo = _mapper.Map<List<AuthorDto>>(labs.registros);
        return new Pager<AuthorDto>(mapeo, labs.totalRegistros, Params.PageIndex, Params.PageSize, Params.Search);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AuthorDto>> GetById(int id)
    {
        Author genero = await _unitOfWork.Authores.GetById(id);
        return _mapper.Map<AuthorDto>(genero);
    }
    [MapToApiVersion("1.1")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAll()
    {
        IEnumerable<Author> generos = await _unitOfWork.Authores.GetAll();
        return _mapper.Map<List<AuthorDto>>(generos);
    }
    [HttpDelete("Delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        Author? genero = await _unitOfWork.Authores.GetById(id);
        if (genero == null)
        {
            return BadRequest();
        }
        _unitOfWork.Authores.Remove(genero);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}