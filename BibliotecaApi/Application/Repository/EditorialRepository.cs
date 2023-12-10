using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interface;
using Persistence.Data;

namespace Application.Repository;
public class EditorialRepository : GenericRepository<Editorial>, IEditorial
{
    private readonly APIContext _context;
    public EditorialRepository(APIContext context) : base(context)
    {
        _context = context;
    }
}