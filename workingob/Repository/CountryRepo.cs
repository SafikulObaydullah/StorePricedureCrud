using Models.Request;
using Models.Response;
using Repository.IRepository;
using System.Data;
using System.Data.SqlClient;

namespace Repository
{
    public class CountryRepo : ICountryRepo
    {
        private SqlConnection connection =
                new SqlConnection("Server=DESKTOP-GRS0037;Database=GEODB;Trusted_Connection=True;MultipleActiveResultSets=True;");

        //Get All
        public List<GetCountry> GetAll()
        {
            var allCountry = new List<GetCountry>();

            try
            {
                var command = new SqlCommand("exec GEODB.geo.CountryCurd @partname='get'", connection);
                //command.CommandType = CommandType.StoredProcedure;
                //command.Parameters.AddWithValue( "get","@partName");

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var country = new GetCountry();
                    country.Id = Convert.ToInt32(reader["intId"]);
                    country.Name = reader["strName"].ToString();
                    country.CreatedBy = reader["strCreatedBy"].ToString();
                    country.CreatedAt = Convert.ToDateTime(reader["dteCreatedAt"]);
                    country.UpdatedBy = reader["strUpdatedBy"] == null ? "" : reader["strUpdatedBy"].ToString();
                    country.UpdatedAt = reader["strUpdatedBy"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["dteUpdatedAt"]);
                    country.IsActive = (bool)reader["isActive"];
                    allCountry.Add(country);
                }

                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return allCountry;
        }

        //GetById
        public GetCountry GetById(int id)
        {
            var country = new GetCountry();

            try
            {
                var command = new SqlCommand("exec GEODB.geo.CountryCurd @partname='getById', @Id='" + id + "'", connection);

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    country.Id = Convert.ToInt32(reader["intId"]);
                    country.Name = reader["strName"].ToString();
                    country.CreatedBy = reader["strCreatedBy"].ToString();
                    country.CreatedAt = Convert.ToDateTime(reader["dteCreatedAt"]);
                    country.UpdatedBy = reader["strUpdatedBy"] == null ? "" : reader["strUpdatedBy"].ToString();
                    country.UpdatedAt = reader["strUpdatedBy"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["dteUpdatedAt"]);
                    country.IsActive = (bool)reader["isActive"];
                }

                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return country;
        }

        //Create
        public int Create(CreateCountry crate)
        {
            int rowsAffected = 0;
            try
            {
                var command = new SqlCommand("exec GEODB.geo.CountryCurd @partname='insert' ,@Name='" + crate.Name + "', @CreatedBy='" + crate.CreatedBy + "'", connection);
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return rowsAffected;
        }

        //Update
        public int Update(int id, UpadteCountry upadteCountry)
        {
            int rowsAffected = 0;
            try
            {
                var command = new SqlCommand("exec GEODB.geo.CountryCurd @partname='update' ,@Name='" + upadteCountry.Name + "',@UpdatedBy='" + upadteCountry.UpdateBy + "' ,@Id='" + id + "'", connection);
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return rowsAffected;
        }
    }
}