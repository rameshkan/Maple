using MapleBC;
using MapleCore.Interfaces;
using MapleDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapleWebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateChartController : BaseController
    {
        ILogger<RateChartController> _logger;
        public RateChartController(IRepository repository, ILogger<RateChartController> log) : base(repository)
        {
            _logger = log;
        }

        [HttpGet]
        [Route("FetchRateChartrByID/{rateChartId}")]
        public RateChart FetchRateChartrByID(Guid rateChartId)
        {
            _logger.LogInformation("Method FetchRateChartrByID called");
            var rateChartBc = new RateChartBC(_repository);
            return rateChartBc.FetchRateChartrByID(rateChartId); ;
        }

        [HttpPost]
        [Route("FetchAllRateCharts")]
        public List<RateChart> FetchAllRateCharts([FromBody] RateChart rateChart)
        {
            var rateChartBc = new RateChartBC(_repository);
            return rateChartBc.FetchAllRateCharts(rateChart); ;
        }

    }
}
