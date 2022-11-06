using Models.Request;
using Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
   public interface IDivisionRepo
   {
      int Create(CreateDivision crate);

      List<GetDivision> GetAll();

      GetDivision GetById(int id);

      int Update(int id, UpdateDivision upadteCountry);
   }
}
