using System;
using System.Collections.Generic;
using System.Text;
using Fukizi.Pfm.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fukizi.Pfm.Persistence.Config
{
    public class PayMethodConf : IEntityTypeConfiguration<PayMethod>
    {
       public void Configure(EntityTypeBuilder<PayMethod> builder)
       {
          builder.HasKey(p => p.Id);
          builder.Property(p => p.Id).HasColumnName("Id");
          builder.Property(p => p.Name).HasColumnName("Name");
          builder.ToTable("PayMenthod", "Accounting");
       }
    }
}
