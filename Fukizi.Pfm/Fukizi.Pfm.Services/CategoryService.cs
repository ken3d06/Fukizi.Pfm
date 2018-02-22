using System;
using System.Collections.Generic;
using System.Text;
using Fukizi.Pfm.Model;
using Fukizi.Pfm.Persistence;
using Fukizi.Pfm.Repository;

namespace Fukizi.Pfm.Services
{
   public enum EnumCategoryType
   {
      Expenditure = 1,
      Revenue,
      PayMethod
   }
   public class CategoryService
   {
      public CategoryService(FukiziPfmDbContext context)
      {
         var expenditureCategoryService = new ExpenditureCategoryService(new ExpenditureCategoryRepository(context));
         CategoryHandlerServices = new Dictionary<EnumCategoryType, ICategoryService<Category>>()
         {
            {EnumCategoryType.Expenditure, expenditureCategoryService }
         };
      }
      public Dictionary<EnumCategoryType, ICategoryService<Category>> CategoryHandlerServices { get; }

      public Dictionary<EnumCategoryType, string> CategoryTypeNamesDictionary => new
         Dictionary<EnumCategoryType, string>()
          {
            {EnumCategoryType.Expenditure, "Expenditure Category" },
            {EnumCategoryType.Revenue, "Revenue Categories" },
            {EnumCategoryType.PayMethod, "Pay Methods" }
          };
   }
}
