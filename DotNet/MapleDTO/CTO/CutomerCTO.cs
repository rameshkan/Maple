using MapleCore.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapleCTO
{
    public class CustomerCTO
    {
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerGender { get; set; }
        public string CustomerCountry { get; set; }
        public DateTime CustomerDOB { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal NetPPrice { get; set; }
        public string CoveragePlanName { get; set; }
    }
}
