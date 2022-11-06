using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Response
{
   public class GetDivision
   {
      public int Id { get; set; }
      public string? Name { get; set; }
      public int? intcountryId { get; set; } 
      public string? CreatedBy { get; set; }
      public DateTime CreatedAt { get; set; }
      public string? UpdatedBy { get; set; }
      public DateTime UpdatedAt { get; set; }
      public bool IsActive { get; set; }
   }
}
