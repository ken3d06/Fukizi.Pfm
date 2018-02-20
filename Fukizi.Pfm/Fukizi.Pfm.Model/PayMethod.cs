using System;
using System.Collections.Generic;
using System.Text;

namespace Fukizi.Pfm.Model
{
   public class PayMethod : Category, IComparable<PayMethod>
   {
      public PayMethod(int id, string categoryName) : base(id, categoryName)
      {
      }

      public int CompareTo(PayMethod other)
      {
         return string.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase);
      }

      public override string ToString()
      {
         return base.Name.ToString();
      }

      public bool Equals(PayMethod payMethod)
      {
         return Id == payMethod.Id &&
                Name == payMethod.Name;
      }
   }
}
