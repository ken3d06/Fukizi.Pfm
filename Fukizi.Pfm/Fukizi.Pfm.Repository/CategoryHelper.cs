using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fukizi.Pfm.Persistence;

namespace Fukizi.Pfm.Repository
{
    public class CategoryHelper
    {
       private readonly FukiziPfmDbContext _fukiziPfmContext;

       public CategoryHelper(FukiziPfmDbContext context)
       {
          _fukiziPfmContext = context;
       }
       public IEnumerable<string> GetAllCategoryNames()
       {
          var categoryNames = new List<string> { "Total Expenditures" };
          categoryNames.AddRange(_fukiziPfmContext.ExpenditureCategories.Select(c => c.Name));
          categoryNames.Add("Total Revenue");

          foreach (var revenueCategoryName in _fukiziPfmContext.RevenueCategories.Select(c => c.Name))
          {
             if (categoryNames.Contains(revenueCategoryName))
             {
                categoryNames[categoryNames.IndexOf(revenueCategoryName)] = $"{revenueCategoryName} - Expenditure";
                categoryNames.Add($"{revenueCategoryName} - Revenue");
             }
             else
             {
                categoryNames.Add(revenueCategoryName);
             }
          }

          return categoryNames;
       }
       public IEnumerable<string> GetAllCategoryNames(string categoryType)
       {
          switch (categoryType.ToLower())
          {
             case "expenditure":
             {
                return _fukiziPfmContext.ExpenditureCategories.Select(c => c.Name).ToList();
             }
             case "revenue":
             {
                return _fukiziPfmContext.RevenueCategories.Select(c => c.Name).ToList();
             }
             default:
             {
                return new List<string>();
             }
          }
       }
   }
}
