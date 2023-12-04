using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Persistence.Data;

namespace Application.Repository;
public class GeneroRepository : GenericRepository<Genero>
{
    private readonly APIContext _context;
    public GeneroRepository(APIContext context) : base(context)
    {
        _context = context;
    }
}