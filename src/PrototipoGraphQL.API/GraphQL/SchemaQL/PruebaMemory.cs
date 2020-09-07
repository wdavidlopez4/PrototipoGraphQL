using GraphQL;
using GraphQL.Types;
using PrototipoGraphQL.API.GraphQL.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototipoGraphQL.API.GraphQL.SchemaQL
{
    public class PruebaMemory : Schema
    {
        public PruebaMemory(IDependencyResolver resolver) : base(resolver)
        {
            this.Query = resolver.Resolve<LibroQuery>();
        }
    }
}
