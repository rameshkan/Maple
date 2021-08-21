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
    class RateChartConfig : IEntityTypeConfiguration<RateChart>
    {
        public void Configure(EntityTypeBuilder<RateChart> entity)
        {
            entity.ToTable("rate_chart");

            entity.Property(e => e.Id)
                .HasColumnName("id");

            entity.Property(e => e.CoveragePlanId)
                .HasColumnName("plan_id");

            entity.Property(e => e.CustomerGender)
               .HasColumnName("cust_gender")
                .HasMaxLength(1);

            entity.Property(e => e.CustomerAge)
               .HasColumnName("age");

            entity.Property(e => e.Constraint)
                .HasColumnName("constraint")
                .HasMaxLength(1);

            entity.Property(e => e.NetPrice)
                .HasColumnName("net_price")
                .HasMaxLength(20);
        }
    }
}
