using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShortMyURL.Data;
using ShortMyURL.Core;

namespace SortMyURL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class URLController : ControllerBase
    {

        private readonly IURLData _IURLData;

        private readonly ILogger<URLController> _logger;


        public URLController(IURLData iURLData)
        {
            _IURLData = iURLData;
        }

        [HttpGet("{Id}")]
        public Task<URL> Get(string Id)
        {
            return _IURLData.GetUrlById(Id);
        }
    }
}
