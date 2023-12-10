using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
    public class TipoDocumento : BaseEntity
    {
        public string Descripcion {get; set;}
        public ICollection<Cliente> Clientes {get; set;}
    }