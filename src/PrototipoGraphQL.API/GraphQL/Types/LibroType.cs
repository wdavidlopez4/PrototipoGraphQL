using GraphQL.Types;
using PrototipoGraphQL.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototipoGraphQL.API.GraphQL.Types
{
    public class LibroType : ObjectGraphType<Libro>
    {
        public LibroType()
        {
            Name = "libro";

            Field(x => x.Id, type: typeof(IdGraphType)).Description("identificador del libro");
            Field(x => x.Nombre).Description("nombre del autor");
            Field(x => x.Descripcion).Description("descripcion del libro");
            Field(x => x.Autor, type: typeof(AutorType)).Description("autor del libro");
        }
    }
}
