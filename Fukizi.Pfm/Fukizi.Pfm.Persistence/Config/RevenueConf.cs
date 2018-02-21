using System;
using System.Collections.Generic;
using System.Text;
using Fukizi.Pfm.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fukizi.Pfm.Persistence.Config
{
    public class RevenueConf : IEntityTypeConfiguration<Revenue>
    {
       public void Configure(EntityTypeBuilder<Revenue> builder)
       {
          builder.HasKey(r => r.Id);
          builder.Property(e => e.Amount).HasColumnName("Amount");
          builder.Property(r => r.CategoryId).HasColumnName("CategoryId");
          builder.Property(r => r.PayMethodId).HasColumnName("PayMethodId");
          builder.Property(r => r.Date).HasColumnName("Date");
         //ToDo: foreign key mapping
          builder.ToTable("Revenue", "Accounting");
       }
    }
}
