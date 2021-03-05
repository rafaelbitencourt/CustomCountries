using CustomCountries.API.GraphqlCore;
using GraphQL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomCountries.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GraphQLController : ControllerBase
    {
        private CountrySchema _schema;

        public GraphQLController(CountrySchema schema)
        {
            _schema = schema;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] GraphQLQuery query)
        {
            var json = "[]"; 
            //    await _schema.ExecuteAsync(_ =>
            //{
            //    _.Query = query.Query;
            //    _.Inputs = query.Variables.ToInputs();
            //});

            return new JsonResult(JsonConvert.DeserializeObject(json));
        }
    }
}
