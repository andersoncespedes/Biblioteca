using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
    public class Editorial : BaseEntity
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int IdCiudad {   get; set; }
        public Ciudad Ciudad    { get; set; }
        public string WebSite { get; set; }
        public ICollection<Libro> Libros { get; set; }

    }