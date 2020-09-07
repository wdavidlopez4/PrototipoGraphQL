using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrototipoGraphQL.API.GraphQL.Queries;
using PrototipoGraphQL.API.Models;

namespace PrototipoGraphQL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        //private readonly IDocumentExecuter documentExecuter;

        //private readonly ISchema schema;

        //public GraphQLController(ISchema schema, IDocumentExecuter documentExecuter)
        //{
        //    this.schema = schema;
        //    this.documentExecuter = documentExecuter;
        //}

        ////public async Task<IActionResult> Post([FromBody] GraphQLModel query)
        ////{
        ////    if (query == null)
        ////    {
        ////        throw new ArgumentException(nameof(query));
        ////    }
        ////    else
        ////    {
        ////        var inputs = query.Variables.ToInputs();
        ////        var schema = new Schema
        ////        {
        ////            Query = new AutorQuery()
        ////        }

        ////        var executionOptions = new ExecutionOptions
        ////        {

        ////        }

        ////    }

        //}
    }
}
