using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interface;
using Persistence.Data;

namespace Application.Repository;
public class AuthorRepository : GenericRepository<Author>, IAuthor
{
    private readonly APIContext _context;
    public AuthorRepository(APIContext context) : base(context)
    {
        _context = context;
    }
}