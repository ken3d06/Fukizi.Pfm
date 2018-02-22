using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fukizi.Pfm.Model;
using Fukizi.Pfm.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Fukizi.Pfm.Repository
{
    public class RevenueRepository
    {
       private readonly FukiziPfmDbContext _fukiziPfmContext;

       public RevenueRepository(FukiziPfmDbContext context)
       {
          _fukiziPfmContext = context;
       }

       public IEnumerable<Revenue> GetRevenues()
       {
          return _fukiziPfmContext.Revenues.Include(r => r.Category).Include(r => r.PayMethod).ToList();
       }

       public Revenue GetRevenue(int id)
       {
          return _fukiziPfmContext.Revenues.Include(r => r.Category).Include(r => r.PayMethod)
             .FirstOrDefault(r => r.Id == id);
       }

       public IEnumerable<Revenue> GetRevenuesForMonthAndYear(int month, int year)
       {
          return _fukiziPfmContext.Revenues.Include(r => r.Category).Include(r => r.PayMethod)
             .Where(r => r.Date.Month == month && r.Date.Year == year).ToList();
       }

       public void SaveRevenue(Revenue revenue)
       {
          if (revenue.Id != 0)
          {
             UpdateRevenue(revenue);
          }
          else
          {
             CreateRevenue(revenue);
          }
         
       }

       public void CreateRevenue(Revenue revenue)
       {
          CleanUpForEF(revenue);
          _fukiziPfmContext.Revenues.Add(revenue);
          _fukiziPfmContext.SaveChanges();
       }

       public void UpdateRevenue(Revenue revenue)
       {
          CleanUpForEF(revenue);
          _fukiziPfmContext.Revenues.Attach(revenue);
          _fukiziPfmContext.SaveChanges();
       }

       private void CleanUpForEF(Revenue revenue)
       {
          if (revenue.CategoryId > 0)
          {
             revenue.Category = null;
          }
          if (revenue.PayMethodId > 0)
          {
             revenue.PayMethod = null;
          }
       }

       public void DeleteRevenue(int id)
       {
          var revToBeRemoved =  _fukiziPfmContext.Revenues.FirstOrDefault(r => r.Id == id);
          if (revToBeRemoved != null) _fukiziPfmContext.Revenues.Remove(revToBeRemoved);
          _fukiziPfmContext.SaveChanges();
       }
    }
}
