using Models.Request;
using Models.Response;

namespace Repository.IRepository
{
    public interface ICountryRepo
    {
        int Create(CreateCountry crate);

        List<GetCountry> GetAll();

        GetCountry GetById(int id);

        int Update(int id, UpadteCountry upadteCountry);
    }
}