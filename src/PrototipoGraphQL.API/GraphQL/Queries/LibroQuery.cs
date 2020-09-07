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
    public class LibroQuery : ObjectGraphType
    {
        private readonly MemoryContext memoryContex;

        public LibroQuery(MemoryContext memoryContex)
        {
            this.memoryContex = memoryContex;

            //consultar un libro
            Field<LibroType>("libro", "retorna un libro", 
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id", Description ="pararle el id"}),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");

                    var libro = this.memoryContex.Libros.Include(x => x.Autor).FirstOrDefault(y => y.Id == id);
                    return libro;
                });

            //consultar todos los libros
            Field<LibroType>("libros",  "retorna todos los libros", 
                resolve: context => 
                {
                    var libros = this.memoryContex.Libros.Include(x => x.Autor);
                    return libros;
                } );
        }
    }
}
