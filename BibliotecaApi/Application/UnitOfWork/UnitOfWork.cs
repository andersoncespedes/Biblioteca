using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repository;
using Domain.Interface;
using Persistence.Data;

namespace Application.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly APIContext _context;
    private ICiudad _ciudad;
    private IAuthor _author;
    private ICliente _cliente;
    private IDepartamento _departamento;
    private IEditorial _editorial;
    private IEstado _estado;
    private IGenero _genero;
    private ILibro _libro;
    private IPais _pais;
    private IRefreshToken _refreshtoken;
    private IRol _rol;
    private ITipoDocumento _tipoDocumento;
    private IUsuario _usuario;
    public UnitOfWork(APIContext context){
        _context = context;
    }

    public IAuthor Authores {
        get{
            _author ??= new AuthorRepository(_context);
            return _author;
        }
    }

    public ICiudad Ciudades {
        get{
            _ciudad ??= new CiudadRepository(_context);
            return _ciudad;
        }
    }

    public ICliente Clientes {
        get{
            _cliente ??= new ClienteRepository(_context);
            return _cliente;
        }
    }

    public IDepartamento Departamentos 
    {
        get{
            _departamento ??= new DepartamentoRepository(_context);
            return _departamento;
        }
    }

    public IEditorial Editoriales {
        get{
            _editorial ??= new EditorialRepository(_context);
            return _editorial;
        }
    }

    public IEstado Estados {
        get{
            _estado ??= new EstadoRepository(_context);
            return _estado;
        }
    }

    public IGenero Generos {
        get{
            _genero ??= new GeneroRepository(_context);
            return _genero;
        }
    }

    public ILibro Libros
    {
        get
        {
            _libro ??= new LibroRepository(_context);
            return _libro;
        }
    }

    public IPais Paises 
    {
        get{
            _pais ??= new PaisRepository(_context);
            return _pais;
        }
    }

    public IRefreshToken RefreshTokens 
    {
        get{
            _refreshtoken ??= new RefreshTokenRepository(_context);
            return _refreshtoken;
        }
    }

    public IRol Roles
    {
        get
        {
            _rol ??= new RolRepository(_context);
            return _rol;
        }
    }

    public ITipoDocumento TipoDocumentos 
    {
        get{
            _tipoDocumento ??= new TipoDocumentoRepository(_context);
            return _tipoDocumento;
        }
    }

    public IUsuario Usuarios 
    {
        get
        {
            _usuario ??= new UsuarioRepository(_context);
            return _usuario;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> SaveAsync()
    {
       return await _context.SaveChangesAsync();
    }
}