using MapleCore.Common;
using System;

namespace MapleDTO
{
    public partial class RateChart : BaseEntity
    {
        public Guid CoveragePlanId { get; set; }
        public string CustomerGender { get; set; }
        public int CustomerAge { get; set; }
        public string Constraint { get; set; }
        public decimal NetPrice { get; set; }
    }
}
