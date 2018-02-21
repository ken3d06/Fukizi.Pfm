using System;
using System.Collections.Generic;
using System.Text;
using Fukizi.Pfm.Model;
using Fukizi.Pfm.Persistence.Config;
using Microsoft.EntityFrameworkCore;

namespace Fukizi.Pfm.Persistence
{
   public class FukiziPfmDbContext : DbContext
   {
      public FukiziPfmDbContext(DbContextOptions options) : base(options)
      {
      }
      public FukiziPfmDbContext(string connectionString) : base(GetOptions(connectionString))
      {
      }

      private static DbContextOptions GetOptions(string connectionString)
      {
         var modelBuilder = new DbContextOptionsBuilder();

         return modelBuilder.UseSqlServer(connectionString).Options;
      }
      //protected override void OnModelCreating(DbModelBuilder modelBuilder)
      //{
      //   base.OnModelCreating(modelBuilder);

      //   modelBuilder.Configurations.Add(new RevenueConf());
      //   modelBuilder.Configurations.Add(new RevenueCategoryConf());
      //   modelBuilder.Configurations.Add(new ExpenditureConf());
      //   modelBuilder.Configurations.Add(new ExpenditureCategoryConf());
      //   modelBuilder.Configurations.Add(new PayMethodConf());
      //}
      public virtual DbSet<Revenue> Revenues { get; set; }

      public virtual DbSet<Expenditure> Expenditures { get; set; }

      public virtual DbSet<RevenueCategory> RevenueCategories { get; set; }

      public virtual DbSet<ExpenditureCategory> ExpenditureCategories { get; set; }

      public virtual DbSet<PayMethod> PayMethods { get; set; }
   }
}
