using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fukizi.Pfm.Model;
using Fukizi.Pfm.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Fukizi.Pfm.Repository
{
    public class ExpenditureCategoryRepository
    {
       private readonly FukiziPfmDbContext _fukiziPfmContext;
       public ExpenditureCategoryRepository(FukiziPfmDbContext context)
       {
          _fukiziPfmContext = context;
       }

       public ExpenditureCategory GetExpenditureCategory(int id)
       {
          return _fukiziPfmContext.ExpenditureCategories.AsNoTracking().FirstOrDefault(x => x.Id == id);
       }

       public ExpenditureCategory GetExpenditureCategoryByName(string name)
       {
          return _fukiziPfmContext.ExpenditureCategories.AsNoTracking()
             .FirstOrDefault(x => x.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));
       }

       public IEnumerable<ExpenditureCategory> GetExpenditureCategories()
       {
          return _fukiziPfmContext.ExpenditureCategories.AsNoTracking().ToList();
       }

       public void Save(ExpenditureCategory expenditureCategory)
       {
          if (expenditureCategory.Id != 0)
          {
             Update(expenditureCategory);
          }
          else
          {
             CreateExpCategory(expenditureCategory);
          }
       }

       public void Update(ExpenditureCategory expenditureCategory)
       {
          var dbCat = _fukiziPfmContext.ExpenditureCategories.FirstOrDefault(e => e.Id == expenditureCategory.Id);
          if (dbCat != null)
          {
             dbCat.Name = expenditureCategory.Name;
          }

          _fukiziPfmContext.SaveChanges();
       }

       public void CreateExpCategory(ExpenditureCategory expenditureCategory)
       {
          if (expenditureCategory == null) return;
          _fukiziPfmContext.ExpenditureCategories.Add(expenditureCategory);
          _fukiziPfmContext.SaveChanges();
       }

       public void RemoveExpCategoryByName(string name)
       {
          var existing = _fukiziPfmContext.ExpenditureCategories.FirstOrDefault(x => x.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));
          if (existing == null) return;
          _fukiziPfmContext.ExpenditureCategories.Remove(existing);
          _fukiziPfmContext.SaveChanges();
       }
   }
}
