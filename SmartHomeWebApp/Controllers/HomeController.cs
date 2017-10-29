using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using SmartHome;

namespace SmartHomeWebApp.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ISchema _schema;

        public HomeController(SmartHomeSchema schema)
        {
            _schema = schema ?? throw new ArgumentNullException(nameof(schema));
        }

        [HttpPost]
        public async Task<string> Get([FromBody] GraphQLQuery request)
        {
            string query = request.Query;
            Inputs inputs = request.Variables.ToInputs();

            var executor = new QueryExecutor(_schema);

            return await executor.Run(query, inputs);
        }
    }

    public class GraphQLQuery
    {
        public string Query { get; set; }

        public string Variables { get; set; }
    }
}
