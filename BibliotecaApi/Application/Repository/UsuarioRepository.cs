using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Persistence.Data;

namespace Application.Repository;
public class UsuarioRepository : GenericRepository<Usuario>
{
    private readonly APIContext _context;
    public UsuarioRepository(APIContext context) : base(context)
    {
        _context = context;
    }
}