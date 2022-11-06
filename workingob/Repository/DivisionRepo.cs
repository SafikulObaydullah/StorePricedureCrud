using Models.Request;
using Models.Response;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
   public class DivisionRepo : IDivisionRepo
   {
      private SqlConnection connection = new SqlConnection("Server=DESKTOP-GRS0037;Database=GEODB;Trusted_Connection=True;MultipleActiveResultSets=True;");
      public int Create(CreateDivision crate)
      {
         throw new NotImplementedException();
      }

      public List<GetDivision> GetAll()
      {
         var allDivision = new List<GetDivision>();
         try
         {
            var cmmand = new SqlCommand("exec GEODB.geo.DivisionCurd @partname='get'", connection);
            
            connection.Open();
            var reader = cmmand.ExecuteReader();
            while (reader.Read())
            {
               var division = new GetDivision();
               division.Id = Convert.ToInt32(reader["intId"]);
               division.Name = reader["strName"].ToString();
               division.intcountryId = Convert.ToInt32(reader["intCountryId"]);
               division.CreatedBy = reader["strCreatedBy"].ToString();
               division.CreatedAt = Convert.ToDateTime(reader["dteCreatedAt"]);
               division.UpdatedBy = reader["strUpdatedBy"] == null ? "" : reader["strUpdatedBy"].ToString();
               division.UpdatedAt = reader["dteUpdatedAt"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["dteUpdatedAt"]); 
               division.IsActive = (bool)reader["isActive"];
               allDivision.Add(division);
            }
            reader.Close();
            connection.Close();
         }
         catch(Exception ex)
         {
            Console.WriteLine(ex.Message);
         }
         finally
         {
            if(connection.State == System.Data.ConnectionState.Open)
            {
               connection.Close();
            }
         }
         return allDivision;
      }

      public GetDivision GetById(int id)
      {
         throw new NotImplementedException();
      }

      public int Update(int id, UpdateDivision upadteCountry)
      {
         throw new NotImplementedException();
      }
   }
}
