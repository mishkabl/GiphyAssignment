using Lib.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiphyAssignment.Controllers
{
    public class GiphySearchController : Controller
    {
        readonly IGiphySearchService _giphyService;
        readonly ILogger<GiphySearchController> _logger;
        readonly IConfiguration _configuration;

        public GiphySearchController(IGiphySearchService giphyService, ILogger<GiphySearchController> logger, IConfiguration configuration)
        {
            _giphyService = giphyService;
            _configuration = configuration;
            _logger = logger;
        }

        [HttpGet]
        [Route("giphyAssignment/searchBy")]
        [ResponseCache(Duration = 360, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new string[] { "searchCriterion" })]
        public async Task<IActionResult> SearchByCritirea([FromQuery(Name = "searchCriterion")] string searchCriterion)
        {
           var result = await _giphyService.SearchByCritirea(searchCriterion ?? string.Empty);
            _logger.LogInformation(result.ToString());
            return Ok(result);
        }

        [HttpGet]
        [Route("giphyAssignment/trending")]
        [ResponseCache(Duration = 360, Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> SearchByTrending()
        {
            var result = await _giphyService.SearchByTrending();
            _logger.LogInformation(result.ToString());
            return Ok(result);
        }
    }
}
