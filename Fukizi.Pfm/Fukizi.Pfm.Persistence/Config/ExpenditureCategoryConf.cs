using System;
using System.Collections.Generic;
using System.Text;
using Fukizi.Pfm.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fukizi.Pfm.Persistence.Config
{
    public class ExpenditureCategoryConf : IEntityTypeConfiguration<ExpenditureCategory>
    {
       public void Configure(EntityTypeBuilder<ExpenditureCategory> builder)
       {
          builder.HasKey(e => e.Id);
          builder.Property(e => e.Id).HasColumnName("Id");
          builder.Property(e => e.Name).HasColumnName("Name");
          builder.ToTable("ExpenditureCategory", "Accounting");
       }
    }
}
