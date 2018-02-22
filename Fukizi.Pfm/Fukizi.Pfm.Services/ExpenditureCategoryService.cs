using System;
using System.Collections.Generic;
using Fukizi.Pfm.Common.Validations;
using Fukizi.Pfm.Model;
using Fukizi.Pfm.Repository;

namespace Fukizi.Pfm.Services
{
   internal class ExpenditureCategoryService : ICategoryService<ExpenditureCategory>
   {
      private readonly ExpenditureCategoryRepository _expenditureCategoryRepository;

      public ExpenditureCategoryService(ExpenditureCategoryRepository expenditureCategoryRepository)
      {
         this._expenditureCategoryRepository = expenditureCategoryRepository;
      }

      public IEnumerable<Category> GetAllCategories()
      {
        return  _expenditureCategoryRepository.GetExpenditureCategories();
      }

      public bool Exists(string name)
      {
         ValidationContract.Required<ArgumentException>(!string.IsNullOrWhiteSpace(name));
         return _expenditureCategoryRepository.GetExpenditureCategoryByName(name) != null;
      }
      public ExpenditureCategory Create(ExpenditureCategory expCategory)
      {
         ValidationContract.Required<ArgumentException>(expCategory != null);
         ValidationContract.Required<ArgumentException>(!string.IsNullOrWhiteSpace(expCategory?.Name));
         if (expCategory == null) return null;
         ValidationContract.Required<ArgumentException>(!Exists(expCategory.Name),
            $"Expenditure category '{expCategory.Name}' is already defined");
         _expenditureCategoryRepository.CreateExpCategory(expCategory);
         return expCategory;
      }
      public ExpenditureCategory Create(string name, int id = 0)
      {
         ValidationContract.Required<ArgumentException>(!string.IsNullOrWhiteSpace(name));
         ValidationContract.Required<ArgumentException>(!Exists(name), $"Expenditure category '{name}' is already defined");

         var expCategory = new ExpenditureCategory(id, name);
         _expenditureCategoryRepository.CreateExpCategory(expCategory);

         return expCategory;
      }

      public void Delete(string name)
      {
         throw new System.NotImplementedException();
      }

      public void Save(int id, string name)
      {
         throw new System.NotImplementedException();
      }
   }
}