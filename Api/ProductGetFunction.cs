using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

using SnackCorp.Shared.Models;

namespace SnackCorp.Api
{
    public class ProductGetFunction
    {
        private readonly ILogger<ProductGetFunction> _logger;
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public ProductGetFunction(ILogger<ProductGetFunction> log)
        {
            _logger = log;
        }

        [FunctionName("ProductGet")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var randomGen = new Random();

            var product = new Product
            {
                id = Guid.NewGuid(),
                name = new string(
                    Enumerable.Repeat(chars, 10)
                        .Select(s => s[randomGen.Next(s.Length)])
                        .ToArray()
                ),
                desc = new string(
                    Enumerable.Repeat(chars, 30)
                        .Select(s => s[randomGen.Next(s.Length)])
                        .ToArray()
                ),
                quantity = randomGen.Next(10),
                price = randomGen.NextSingle()
            };

            return new OkObjectResult(product);
        }
    }
}

