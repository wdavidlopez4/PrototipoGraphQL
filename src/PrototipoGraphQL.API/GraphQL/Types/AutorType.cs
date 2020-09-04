using GraphQL.Types;
using PrototipoGraphQL.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototipoGraphQL.API.GraphQL.Types
{
    public class AutorType : ObjectGraphType<Autor>
    {
        public AutorType()
        {
            this.Name = "Autor";

            Field(x => x.Id, type: typeof(IdGraphType)).Description("identificador del autor");
            Field(x => x.Anios).Description("años del autor");
            Field(x => x.Nacionalidad).Description("nacionalidad del autor");
            Field(x => x.Nombre).Description("nombre completo del autor");
            Field(x => x.Libros, type: typeof(ListGraphType<LibroType>)).Description("lista de libros del autor");
        }
    }
}
