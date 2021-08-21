using MapleCore.Interfaces;
using MapleDTO;
using System;
using System.Linq;
using System.Collections.Generic;

namespace MapleBC
{
    public class RateChartBC
    {
        private readonly IRepository _repository;

        public RateChartBC(IRepository repository )
        {
            _repository = repository;
            
        }

        public RateChart FetchRateChartrByID(Guid rateChartId)
        {
            return _repository.GetById<RateChart>(rateChartId);
        }

        public List<RateChart> FetchAllRateCharts(RateChart rChart)
        {
            return _repository.List<RateChart>(a => string.IsNullOrEmpty(rChart.CustomerGender) || a.CustomerGender == rChart.CustomerGender);
        }
    }
}
