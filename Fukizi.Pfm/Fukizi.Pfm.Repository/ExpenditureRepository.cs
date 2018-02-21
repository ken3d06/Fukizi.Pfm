using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fukizi.Pfm.Model;
using Fukizi.Pfm.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Fukizi.Pfm.Repository
{
    public class ExpenditureRepository
    {
       private readonly FukiziPfmDbContext _fukiziPfmContext;

       public ExpenditureRepository(FukiziPfmDbContext context)
       {
          _fukiziPfmContext = context;
       }

       public IEnumerable<Expenditure> GetExpenditures()
       {
          return _fukiziPfmContext.Expenditures.Include(e => e.Category).Include(e => e.PayMethod).ToList();
       }

       public Expenditure GetExpenditure(int id)
       {
          return _fukiziPfmContext.Expenditures.Include(e => e.Category).Include(e => e.PayMethod)
             .FirstOrDefault(e => e.Id == id);
       }

       public void CreateExpenditure(Expenditure expenditure)
       {
          CleanUpForEF(expenditure);
          _fukiziPfmContext.Expenditures.Add(expenditure);
          _fukiziPfmContext.SaveChanges();
       }

       public void UpdateExpenditure(Expenditure expenditure)
       {
          CleanUpForEF(expenditure);
          _fukiziPfmContext.Expenditures.Attach(expenditure);
          _fukiziPfmContext.SaveChanges();
       }

       public void SaveExpenditure(Expenditure expenditure)
       {
          if (expenditure.Id != 0)
          {
             UpdateExpenditure(expenditure);
          }
          else
          {
             CreateExpenditure(expenditure);
          }
       }

       public void DeleteExpenditure(int id)
       {
          var exp = _fukiziPfmContext.Expenditures.FirstOrDefault(e => e.Id == id);
          if (exp != null) _fukiziPfmContext.Expenditures.Remove(exp);
          _fukiziPfmContext.SaveChanges();

       }

       public IEnumerable<Expenditure> GetExpendituresForMonthAndYear(int month, int year)
       {
          return _fukiziPfmContext.Expenditures.Include(e => e.Category).Include(e => e.PayMethod)
             .Where(e => e.Date.Month == month && e.Date.Year == year).ToList();
       }
      public static void CleanUpForEF(Expenditure expenditure)
       {
          if (expenditure.CategoryId > 0)
          {
             expenditure.Category = null;
          }
          if (expenditure.PayMethodId > 0)
          {
             expenditure.PayMethod = null;
          }
       }
    }
}
