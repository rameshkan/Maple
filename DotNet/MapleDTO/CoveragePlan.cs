using MapleCore.Common;
using System;

namespace MapleDTO
{
    public class CoveragePlan : BaseEntity
    {
        public string PlanName { get; set; }
        public DateTime ElgDateFrom { get; set; }
        public DateTime ElgDateTo { get; set; }
        public string ElgCountry { get; set; }
    }
}
