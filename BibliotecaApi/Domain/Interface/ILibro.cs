using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interface;
public interface ILibro : IGenericRepository<Libro>
{
    Task AddPrestamo(IEnumerable<Prestamo> prestamos);
}