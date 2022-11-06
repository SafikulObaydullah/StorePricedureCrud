using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Request
{
   public class UpdateDivision
   {
      public string? Name { get; set; }
      public int? divisionId { get; set; }
      public string? UpdateBy { get; set; }
   }
}
