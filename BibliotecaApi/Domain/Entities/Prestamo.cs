using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
    public class Prestamo
    {
        public int IdClienteFk {get; set;}
        public Cliente Cliente {get; set;}
        public int IdLibroFk {get; set;}
        public Libro Libro {get; set;}
        public int IdUsuario {get; set; }
        public Usuario Usuario {get; set;}
        public DateOnly FechaPrestada {get; set;}
        public DateOnly FechaVencimiento {get; set;}
        public DateOnly ? FechaDevolucion {get; set;}
    }