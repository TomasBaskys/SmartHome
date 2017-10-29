using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Http;
using GraphQL.Types;

namespace SmartHome
{
    public class QueryExecutor
    {
        private readonly ISchema _schema;

        public QueryExecutor(ISchema schema)
        {
            _schema = schema ?? throw new ArgumentNullException(nameof(schema));
        }

        public async Task<string> Run(string query, Inputs inputs)
        {
            var result = await new DocumentExecuter().ExecuteAsync(_ =>
                {
                    _.Schema = _schema;
                    _.Query = query;
                    _.Inputs = inputs;
                })
                .ConfigureAwait(false);

            return new DocumentWriter(indent: true).Write(result);
        }
    }
}
