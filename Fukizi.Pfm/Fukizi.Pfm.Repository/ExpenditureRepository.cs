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
          
       }

       public void UpdateExpenditure(Expenditure expenditure)
       {
          
       }

       public void SaveExpenditure(Expenditure expenditure)
       {
          
       }

       public void DeleteExpenditure(Expenditure expenditure)
       {
          
       }

       public static void CleanUpForEF(Expenditure expenditure)
       {
          
       }
    }
}
