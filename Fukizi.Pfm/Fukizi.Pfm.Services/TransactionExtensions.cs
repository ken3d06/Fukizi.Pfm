using System;
using System.Collections.Generic;
using System.Text;
using Fukizi.Pfm.Model;

namespace Fukizi.Pfm.Services
{
    public class TransactionExtensions
    {
       public static Expenditure TryParseToExpenditure(Transaction t)
       {
          if (!(t is Expenditure exp))
          {
             throw new ArgumentException("This is a wrong type of transaction");
          }
          exp.Id = t.Id;
          exp.Amount = t.Amount;
          exp.Date = t.Date;
          exp.Description = t.Description;
          exp.PayMethod = t.PayMethod;
          exp.PayMethodId = t.PayMethodId;
          exp.CategoryId = t.CategoryId;
          exp.Category = t.Category != null ? new ExpenditureCategory(t.Category.Id, t.Category.Name) : null;
          return exp;
       }
   }
}
