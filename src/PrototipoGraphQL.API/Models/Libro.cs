using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototipoGraphQL.API.Models
{
    public class Libro
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int IdAutor { get; set; }

        public Autor Autor { get; set; }
    }
}
