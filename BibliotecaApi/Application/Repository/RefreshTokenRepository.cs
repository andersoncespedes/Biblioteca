using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interface;
using Persistence.Data;

namespace Application.Repository;
public class RefreshTokenRepository : GenericRepository<RefreshToken>, IRefreshToken
{
    private readonly APIContext _context;
    public RefreshTokenRepository(APIContext context) : base(context)
    {
        _context = context;
    }
}