using System;
using System.Collections.Generic;
using System.Text;
using Fukizi.Pfm.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fukizi.Pfm.Persistence.Config
{
    public class RevenueCategoryConf : IEntityTypeConfiguration<RevenueCategory>
    {
       public void Configure(EntityTypeBuilder<RevenueCategory> builder)
       {
          builder.HasKey(r => r.Id);
          builder.Property(r => r.Id).HasColumnName("Id");
          builder.Property(r => r.Name).HasColumnName("name");
          builder.ToTable("RevenueCategory", "Accounting");
       }
    }
}
