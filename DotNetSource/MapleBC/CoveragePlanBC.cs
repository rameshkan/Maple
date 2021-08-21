using MapleCore.Interfaces;
using MapleDTO;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace MapleBC
{
    public class CoveragePlanBC
    {
        private readonly IRepository _repository;
        public CoveragePlanBC(IRepository repository)
        {
            _repository = repository;
        }

        public CoveragePlan FetchCoveragePlanByID(Guid coveragePlanId)
        {
            return _repository.GetById<CoveragePlan>(coveragePlanId);
        }

        public List<CoveragePlan> FetchAllCoveragePlans(CoveragePlan cPlan)
        {
            //Sample list to fetch the data based on the given search values.
            return _repository.List<CoveragePlan>(a => string.IsNullOrEmpty(cPlan.PlanName) ||  a.PlanName == cPlan.PlanName );
        }

    }
}
