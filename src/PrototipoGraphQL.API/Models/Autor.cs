using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototipoGraphQL.API.Models
{
    public class Autor
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Nacionalidad { get; set; }

        public int Anios { get; set; }

        public List<Libro> Libros { get; set; }
    }
}
