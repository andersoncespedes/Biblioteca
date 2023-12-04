using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Persistence.Data;

namespace Application.Repository;
public class LibroRepository : GenericRepository<Libro>
{
    private readonly APIContext _context;
    public LibroRepository(APIContext context) : base(context)
    {
        _context = context;
    }
}