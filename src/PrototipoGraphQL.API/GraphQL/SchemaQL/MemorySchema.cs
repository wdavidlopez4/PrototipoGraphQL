using GraphQL;
using GraphQL.Types;
using PrototipoGraphQL.API.GraphQL.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototipoGraphQL.API.GraphQL.SchemaQL
{
    public class MemorySchema : Schema
    {
        public MemorySchema(IDependencyResolver resolver): base (resolver)
        {
            this.Query = resolver.Resolve<AutorQuery>();
        }
    }
}
