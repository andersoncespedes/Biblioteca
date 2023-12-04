using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Persistence.Data;

namespace Application.Repository;
public class TipoDocumentoRepository : GenericRepository<TipoDocumento>
{
    private readonly APIContext _context;
    public TipoDocumentoRepository(APIContext context) : base(context)
    {
        _context = context;
    }
}