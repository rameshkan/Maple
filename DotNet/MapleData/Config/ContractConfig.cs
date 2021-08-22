using MapleDTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleData.Config
{
    class ContractConfig : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> entity)
        {
            entity.ToTable("contracts");

            entity.Property(e => e.Id)
                .HasColumnName("id");

            entity.Property(e => e.CoveragePlanId)
                .HasColumnName("plan_id");

            entity.Property(e => e.CustomerName)
                .HasColumnName("cust_name")
                .HasMaxLength(100);

            entity.Property(e => e.CustomerAddress)
               .HasColumnName("cust_address")
               .HasMaxLength(300);

            entity.Property(e => e.CustomerCountry)
                .HasColumnName("cust_country")
                .HasMaxLength(5);

            entity.Property(e => e.CustomerGender)
                .HasColumnName("cust_gender")
                .HasMaxLength(1);

            entity.Property(e => e.CustomerDOB)
                .HasColumnName("cust_dob");

            entity.Property(e => e.SaleDate)
                .HasColumnName("sale_date");

            entity.Property(e => e.RateChartId)
                 .HasColumnName("rate_chart_id");
        }
    }
}
