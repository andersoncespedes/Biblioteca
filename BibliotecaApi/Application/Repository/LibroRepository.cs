using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;
public class LibroRepository : GenericRepository<Libro>, ILibro
{
    private readonly APIContext _context;
    public LibroRepository(APIContext context) : base(context)
    {
        _context = context;
    }
    public override async void Add(Libro entity)
    {
        using var trans = _context.Database.BeginTransaction();
        List<Genero> gen = new();
        foreach(Genero x in entity.Generos.ToList()){
            var ger = _context.Generos.Find(x.Id);
            if(ger != null){
                entity.Generos.Remove(x);
                entity.Generos.Add(ger);
            }
        }
        _context.Libros.Add(entity);
        await trans.CommitAsync();
    }
    public override Task<Libro> GetById(int id)
    {
        return _context.Libros
        .Include(e => e.Generos)
        .FirstAsync(e => e.Id == id);
    }
}