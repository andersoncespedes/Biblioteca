using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
    public class Genero : BaseEntity
    {
        public string ? Descripcion {get; set;}
        public ICollection<Libro> Libros {get; set;}
        public ICollection<LibroGenero> libroGeneros {get; set;}
    }