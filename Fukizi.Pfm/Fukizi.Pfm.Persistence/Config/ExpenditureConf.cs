using System;
using System.Collections.Generic;
using System.Text;
using Fukizi.Pfm.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fukizi.Pfm.Persistence.Config
{
   public class ExpenditureConf : IEntityTypeConfiguration<Expenditure>
   {
      public void Configure(EntityTypeBuilder<Expenditure> builder)
      {
         builder.HasKey(e => e.Id);
         builder.Property(e => e.Id).HasColumnName("Id");
         builder.Property(e => e.Amount).HasColumnName("Amount");
         builder.Property(e => e.Date).HasColumnName("Date").HasColumnType("Date");
         builder.Property(e => e.CategoryId).HasColumnName("CategoryId");
         builder.Property(e => e.PayMethodId).HasColumnName("PayMethodId");
         //ToDo: foreign key mappings
         builder.ToTable("Expenditure", "Accounting");
      }
   }
}
