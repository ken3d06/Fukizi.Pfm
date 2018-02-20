using System;
using System.Collections.Generic;
using System.Text;

namespace Fukizi.Pfm.Model
{
   public class Category
   {
      public Category(int id, string categoryName)
      {
         if (string.IsNullOrEmpty(categoryName))
         {
            throw new ArgumentException("categoryName");
         }
         Id = id;
         Name = categoryName;
      }
      public int Id { get; set; }
      public string Name { get; set; }
   }
}
