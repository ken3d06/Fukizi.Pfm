using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fukizi.Pfm.Model;
using Fukizi.Pfm.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Fukizi.Pfm.Repository
{
    public class RevenueCategoryRepository
    {
       private readonly FukiziPfmDbContext _fukiziPfmContext;
       public RevenueCategoryRepository(FukiziPfmDbContext context)
       {
          _fukiziPfmContext = context;
       }

       public RevenueCategory GetRevenueCategory(int id)
       {
          return _fukiziPfmContext.RevenueCategories.AsNoTracking().FirstOrDefault(i => i.Id == id);
       }

       public RevenueCategory GetRevCatByName(string name)
       {
          return _fukiziPfmContext.RevenueCategories.AsNoTracking().FirstOrDefault(i => i.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));
       }

       public IEnumerable<RevenueCategory> GetRevenueCategories()
       {
          return _fukiziPfmContext.RevenueCategories.AsNoTracking().ToList();
       }

       public void Save(RevenueCategory revenueCategory)
       {
          if (revenueCategory.Id != 0)
          {
             Update(revenueCategory);
          }
          else
          {
             Create(revenueCategory);
          }
       }

       public void Update(RevenueCategory revenueCategory)
       {
          var dbCat = _fukiziPfmContext.RevenueCategories.FirstOrDefault(ec => ec.Id == revenueCategory.Id);
          if (dbCat != null)
          {
             dbCat.Name = revenueCategory.Name;
          }
          _fukiziPfmContext.SaveChanges();
       }

       public void Create(RevenueCategory revenueCategory)
       {
          if (revenueCategory == null)
          {
             return;
          }
          _fukiziPfmContext.RevenueCategories.Add(revenueCategory);
          _fukiziPfmContext.SaveChanges();
       }

       public void RemoveByName(string name)
       {
          var existing = _fukiziPfmContext.RevenueCategories.FirstOrDefault(i => i.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));
          if (existing == null) return;
          _fukiziPfmContext.RevenueCategories.Remove(existing);
       }
   }
}
