using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interface;
    public interface IUnitOfWork
    {
        IAuthor Authores {get;}
        ICiudad Ciudades {get;}
        ICliente Clientes {get;}
        IDepartamento Departamentos {get;}
        IEditorial Editoriales {get;}
        IEstado Estados {get;}
        IGenero Generos {get;}
        ILibro Libros {get;}
        IPais Paises {get;}
        IRefreshToken RefreshTokens {get;}
        IRol Roles {get;}
        ITipoDocumento TipoDocumentos {get;}
        IUsuario Usuarios {get;}
        Task<int> SaveAsync();
    }