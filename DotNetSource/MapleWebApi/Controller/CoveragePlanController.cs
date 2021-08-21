using MapleBC;
using MapleCore.Interfaces;
using MapleDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapleWebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoveragePlanController : BaseController
    {

        ILogger<ContractController> _logger;
        public CoveragePlanController(IRepository repository, ILogger<ContractController> log) : base(repository)
        {
            _logger = log;
        }

        [HttpGet]
        [Route("FetchCoveragePlanById/{coveragePlanId}")]
        public CoveragePlan FetchCoveragePlanById(Guid coveragePlanId)
        {
            _logger.LogInformation("Method FetchCoveragePlanById called");
            var coverageBC = new CoveragePlanBC(_repository);
            return coverageBC.FetchCoveragePlanByID(coveragePlanId); ;
        }

        [HttpPost]
        [Route("FetchAllCoveragePlan")]
        public List<CoveragePlan> FetchAllCoveragePlan([FromBody]CoveragePlan cPlans)
        {
            //Json format to fetch data. Below json will return the plan name with 'Gold'
            //{
            //    "planName": "Gold",
            //    "elgDateFrom": "",
            //    "elgDateTo": "",
            //    "elgCountry": "",
            //    "planCode": ""
            //}
            var coverageBC = new CoveragePlanBC(_repository);
            return coverageBC.FetchAllCoveragePlans(cPlans); ;
        }

    }
}
