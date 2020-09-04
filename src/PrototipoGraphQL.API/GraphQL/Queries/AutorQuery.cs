using GraphQL;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using PrototipoGraphQL.API.context;
using PrototipoGraphQL.API.GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototipoGraphQL.API.GraphQL.Queries
{
    public class AutorQuery : ObjectGraphType
    {
        private readonly MemoryContext memoryContext;

        public AutorQuery(MemoryContext memoryContext)
        {
            this.memoryContext = memoryContext;

            //consulta un autor
            Field<AutorType>("autor", "retorna un autor", 
                arguments: new QueryArguments( new QueryArgument<IdGraphType> { Name = "id", Description = "id del autor"}),
                resolve: context => 
                {

                    var id = context.GetArgument<int>("id");
                    var autor = this.memoryContext.Autores.Include(x => x.Libros).FirstOrDefault(y => y.Id == id);
                    return autor;
                }
                );

            //consulta una lista de autores
            Field<ListGraphType<AutorType>>("autores", "retorna una lista de autores ",
                //si no le pasamos un argumento obtenemos un listado
                resolve: context =>
                {
                    var autores = this.memoryContext.Autores.Include(x => x.Libros);
                    return autores;
                }
                );
        }
    }
}
