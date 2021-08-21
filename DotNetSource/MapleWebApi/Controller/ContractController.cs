using MapleBC;
using MapleCore.Interfaces;
using MapleCTO;
using MapleDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace MapleWebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : BaseController
    {

        ILogger<ContractController> _logger;
        public ContractController(IRepository repository, ILogger<ContractController> log) : base(repository)
        {
            _logger = log;
        }
        [HttpGet]
        [Route("FetchContractById/{contractId}")]
        public Contract FetchContractById(Guid contractId)
        {
            _logger.LogInformation("Method FetchContractById called");
            var contractBC = new ContractBC(_repository);
            return contractBC.FetchContractById(contractId); ;
        }

        [HttpPost]
        [Route("FetchAllContracts")]
        public List<CustomerCTO> FetchAllContracts([FromBody] CustomerCTO customer)
        {
            var contractBC = new ContractBC(_repository);
            return contractBC.FetchAllContracts(customer); ;
        }

        [HttpPost]
        [Route("CreateContract")]
        public Contract CreateContract([FromBody] CustomerCTO customer)
        {
            var contractBC = new ContractBC(_repository);
            return contractBC.CreateContract(customer); ;
        }

        [HttpPost]
        [Route("ModifyContract")]
        public Contract ModifyContract([FromBody] Contract contract)
        {
            var contractBC = new ContractBC(_repository);
            return contractBC.UpdateContract(contract); ;
        }

        [HttpGet]
        [Route("RemoveContract/{contractId}")]
        public string RemoveContract(Guid contractId)
        {
            var contractBC = new ContractBC(_repository);
            contractBC.DeleteContract(contractId);
            return "Contract deleted successfully";
        }


    }
}
