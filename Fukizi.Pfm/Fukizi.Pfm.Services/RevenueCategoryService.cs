using System;
using System.Collections.Generic;
using System.Text;
using Fukizi.Pfm.Common.Validations;
using Fukizi.Pfm.Model;
using Fukizi.Pfm.Repository;

namespace Fukizi.Pfm.Services
{
   public class RevenueCategoryService : ICategoryService<RevenueCategory>
   {
      private readonly RevenueCategoryRepository _repository;

      public RevenueCategoryService(RevenueCategoryRepository repository)
      {
         _repository = repository;
      }
      public IEnumerable<Category> GetAllCategories()
      {
         return _repository.GetRevenueCategories();
      }

      public bool Exists(string name)
      {
         ValidationContract.Required<ArgumentException>(!string.IsNullOrWhiteSpace(name));
         return _repository.GetRevCatByName(name) != null;
      }
      public RevenueCategory Create(RevenueCategory revenueCategory)
      {
         ValidationContract.Required<ArgumentException>(revenueCategory != null);
         ValidationContract.Required<ArgumentException>(!string.IsNullOrWhiteSpace(revenueCategory?.Name));
         ValidationContract.Required<ArgumentException>(revenueCategory != null && !Exists(revenueCategory.Name), $"Revenue category '{revenueCategory.Name}' is already defined");

        
         _repository.Create(revenueCategory);

         return revenueCategory;
      }
      public RevenueCategory Create(string name, int id = 0)
      {
         ValidationContract.Required<ArgumentException>(!string.IsNullOrWhiteSpace(name));
         ValidationContract.Required<ArgumentException>(!Exists(name), $"Revenue category '{name}' is already defined");

         var revenueCategory = new RevenueCategory(id, name);
         _repository.Create(revenueCategory);

         return revenueCategory;
      }

      public void Delete(string name)
      {
         ValidationContract.Required<ArgumentException>(!string.IsNullOrWhiteSpace(name));
         _repository.RemoveByName(name);
      }

      public void Save(int id, string name)
      {
         ValidationContract.Required<ArgumentException>(!string.IsNullOrWhiteSpace(name));
         ValidationContract.Required<ArgumentException>(!Exists(name), $"Revenue category '{name}' is already defined");

         var revenueCategory = new RevenueCategory {Id = id, Name = name};
         _repository.Save(revenueCategory);
      }
   }
}
