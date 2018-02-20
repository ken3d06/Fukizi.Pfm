using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Fukizi.Pfm.Model
{
   public class Transaction
   {
      public int Id { get; set; }
      public decimal Amount { get; set; }
      public DateTime Date { get; set; }
      public int CategoryId { get; set; }
      public Category Category { get; set; }
      public int PayMethodId { get; set; }
      public PayMethod PayMethod { get; set; }
      public string Description { get; set; }
   }

}
