using Models.Request;
using Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
   public interface IDistrictRepo
   {
      int Create(CreateDistrict crate);

      List<GetCountry> GetAll();

      GetCountry GetById(int id);

      int Update(int id, UpadteCountry upadteCountry);

   }
}
