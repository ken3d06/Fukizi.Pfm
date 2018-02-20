using System;
using System.Collections.Generic;
using System.Text;

namespace Fukizi.Pfm.Model
{
   public class Revenue : Transaction
   {
      public Revenue(decimal amount, DateTime date, RevenueCategory revenueCategory,
         PayMethod payMethod, string description, int id = 0)
      {
         Amount = amount;
         Category = revenueCategory;
         Description = description;
         Date = date;
         Id = id;
         PayMethod = payMethod;
      }
      public Revenue(decimal amount, DateTime date, int categoryId, int payMethodId, string description)
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
      public new RevenueCategory Category { get; }
      public new int PayMethodId { get; set; }
      public new PayMethod PayMethod { get; }
      public new string Description { get; }

      public override bool Equals(object objRevenue)
      {
         var revenueCompare = (Revenue)objRevenue;
         if (revenueCompare == null) return false;


         return Amount == revenueCompare.Amount &&
                (Category == null && revenueCompare.Category == null || Category?.Equals(revenueCompare.Category) == true) &&
                Description == revenueCompare.Description &&
                Date == revenueCompare.Date &&
                Id == revenueCompare.Id &&
                (PayMethod == null && revenueCompare.PayMethod == null || PayMethod?.Equals(revenueCompare.PayMethod) == true);
      }

      public override int GetHashCode()
      {
         return new {Id,Amount, Category, Description,Date, PayMethod}.GetHashCode() ;
      }
   }
}
