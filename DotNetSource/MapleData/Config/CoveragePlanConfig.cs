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
    class CoveragePlanConfig : IEntityTypeConfiguration<CoveragePlan>
    {
        public void Configure(EntityTypeBuilder<CoveragePlan> entity)
        {
            entity.ToTable("coverage_plan");

            entity.Property(e => e.Id)
                .HasColumnName("id");

            entity.Property(e => e.PlanName)
                .HasColumnName("plan_name")
                .HasMaxLength(30);

            entity.Property(e => e.ElgDateFrom)
               .HasColumnName("elg_date_from");

            entity.Property(e => e.ElgDateTo)
               .HasColumnName("elg_date_to");

            entity.Property(e => e.ElgCountry)
                .HasColumnName("elg_country")
                .HasMaxLength(5);
        }
    }
}
