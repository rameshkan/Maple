using MapleCore.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapleDTO
{
    public partial class Contract : BaseEntity
    {
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerGender { get; set; }
        public DateTime CustomerDOB { get; set; }
        public DateTime SaleDate { get; set; }
        public Guid CoveragePlanId { get; set; }
        public Guid RateChartId { get; set; }
        [NotMapped]
        public string PlanName{ get; set; }
        [NotMapped]
        public decimal NetPPrice { get; set; }
    }
}
