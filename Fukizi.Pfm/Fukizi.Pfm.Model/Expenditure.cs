using System;
using System.Collections.Generic;
using System.Text;

namespace Fukizi.Pfm.Model
{
   public class Expenditure : Transaction
   {
      public Expenditure(decimal amount, DateTime date, ExpenditureCategory expenseCategory,
         PayMethod paymentMethod, string comment, int id = 0)
      {
         Amount = amount;
         Category = expenseCategory;
         Description = comment;
         Date = date;
         Id = id;
         PayMethod = paymentMethod;
      }

      public Expenditure(decimal amount, DateTime date, int categoryId, int payMethodId, string description)
      {
         Amount = amount;
         CategoryId = categoryId;
         Description = description;
         Date = date;
         PayMethodId = payMethodId;
      }
      public new int Id { get; }
      public new decimal Amount { get; }
      public new DateTime Date { get; }
      public new int CategoryId { get; set; }
      public new ExpenditureCategory Category { get; }
      public new int PayMethodId { get; set; }
      public new PayMethod PayMethod { get; }
      public new string Description { get; }

      public override bool Equals(object obj)
      {
         var expenseCompare = (Expenditure)obj;
         if (expenseCompare == null) return false;


         return Amount == expenseCompare.Amount &&
                (Category == null && expenseCompare.Category == null || Category?.Equals(expenseCompare.Category) == true) &&
                Description == expenseCompare.Description &&
                Date == expenseCompare.Date &&
                Id == expenseCompare.Id &&
                (PayMethod == null && expenseCompare.PayMethod == null || PayMethod?.Equals(expenseCompare.PayMethod) == true);
      }

      public override int GetHashCode()
      {
         return new { Id, Amount, Category, Description, Date, PayMethod }.GetHashCode();
      }
   }
}
