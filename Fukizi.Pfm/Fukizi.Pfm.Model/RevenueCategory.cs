using System;
using System.Collections.Generic;
using System.Text;

namespace Fukizi.Pfm.Model
{
    public class RevenueCategory : Category , IComparable<RevenueCategory>
    {
       public RevenueCategory(int id, string categoryName) : base(id, categoryName)
       {
       }

       public int CompareTo(RevenueCategory other)
       {
          return string.CompareOrdinal(Name, other.Name);
       }

       public override string ToString()
       {
          return base.Name;
       }

       public bool Equals(RevenueCategory revenueCategory)
       {
          return Id == revenueCategory.Id &&
                 Name == revenueCategory.Name;
       }
    }
}
