using System;
using System.Collections.Generic;
using System.Text;

namespace Fukizi.Pfm.Model
{
    public class ExpenditureCategory : Category, IComparable<ExpenditureCategory>
    {
       public ExpenditureCategory(int id, string categoryName) : base(id, categoryName)
       {
       }

       public int CompareTo(ExpenditureCategory other)
       {
          return string.CompareOrdinal(Name, other.Name);
       }

       public override string ToString()
       {
          return Name;
       }

       public bool Equals(ExpenditureCategory  expenditurecateGory)
       {
          return Id == expenditurecateGory.Id && Name == expenditurecateGory.Name;
       }
    }
}
