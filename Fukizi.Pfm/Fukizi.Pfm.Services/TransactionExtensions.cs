using System;
using System.Collections.Generic;
using System.Text;
using Fukizi.Pfm.Model;

namespace Fukizi.Pfm.Services
{
    public class TransactionExtensions
    {
       public static Expenditure TryParseToExpenditure(Transaction transaction)
       {
          if (!(transaction is Expenditure expenditure))
          {
             throw new ArgumentException("This is a wrong type of transaction");
          }
          expenditure.Id = transaction.Id;
          expenditure.Amount = transaction.Amount;
          expenditure.Date = transaction.Date;
          expenditure.Description = transaction.Description;
          expenditure.PayMethod = transaction.PayMethod;
          expenditure.PayMethodId = transaction.PayMethodId;
          expenditure.CategoryId = transaction.CategoryId;
          expenditure.Category = transaction.Category != null ? new ExpenditureCategory(transaction.Category.Id, transaction.Category.Name) : null;
          return expenditure;
       }
       public static Revenue TryParseToRevenue(Transaction transaction)
       {
          if (!(transaction is Revenue revenue))
          {
             throw new ArgumentException("The transaction is the wrong type");
          }
          revenue.Id = transaction.Id;
          revenue.Amount = transaction.Amount;
          revenue.Date = transaction.Date;
          revenue.Description = transaction.Description;
          revenue.PayMethod = transaction.PayMethod;
          revenue.PayMethodId = transaction.PayMethodId;
          revenue.CategoryId = transaction.CategoryId;
          revenue.Category = transaction.Category != null ? new RevenueCategory(transaction.Category.Id, transaction.Category.Name) : null;
          return revenue;
       }
   }
}
