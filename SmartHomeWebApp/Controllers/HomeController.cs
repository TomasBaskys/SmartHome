using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using SmartHome;
using SmartHome.Laptop;
using YoutubeClient;

namespace SmartHomeWebApp.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ISchema _schema;
        private readonly ChromeHandler _chromeHandler;

        public HomeController(SmartHomeSchema schema, ChromeHandler chromeHandler)
        {
            _schema = schema ?? throw new ArgumentNullException(nameof(schema));
            _chromeHandler = chromeHandler ?? throw new ArgumentNullException(nameof(chromeHandler));
        }

        [HttpGet]
        public void Get()
        {
            var handler = new LaptopHandler();

            handler.Laptop();
        }

        [HttpPost]
        [Route("chrome")]
        public async Task<string> Chrome([FromBody] Chrome chrome)
        {
            await _chromeHandler.MakeRequest(chrome.Url).ConfigureAwait(false);

            return "Play the music!";
        }

        [HttpPost]
        public async Task<string> Post([FromBody] GraphQLQuery request)
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

    public class Chrome
    {
        public string Url;
    }
}
