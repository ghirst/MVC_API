using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MVCDemoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DisplaySomethingController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Hello World", "Hola Mundo", "Bonjour le monde", "Helo Byd", "Hàlo a Shaoghail"
        };

        //private readonly ILogger<displaySomethingController> _logger;

        //public displaySomethingController(ILogger<displaySomethingController> logger)
        //{
        //    _logger = logger;
        //}

        [HttpGet]
        public IEnumerable<APIPage> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new APIPage
            {
                Date = DateTime.Now.AddDays(index),
                RandomNumber = rng.Next(-99, 999),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
