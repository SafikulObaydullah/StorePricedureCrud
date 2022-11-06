using Microsoft.AspNetCore.Mvc;
using Models.Request;
using Repository.IRepository;

namespace storedProceedureCurd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : Controller
    {
        private readonly ICountryRepo _countryRepo;
        private readonly ILogger<CountryController> _logger;

        public CountryController(ICountryRepo countryRepo, ILogger<CountryController> logger)
        {
            _countryRepo = countryRepo;
            _logger = logger;
        }

        //GetAll
        [HttpGet(Name = "GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var res = _countryRepo.GetAll();
                if(res.Count != 0)
                {
                    _logger.LogInformation($"Total {res.Count} country returned");
                    return Ok(res);
                }
                else
                {
                    _logger.LogInformation($"Error occured when get all");
                    return BadRequest();

                }
               
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        //Get by Id
        [HttpGet("{id}", Name = "GetById")]
        public IActionResult GetById(int id)
        {
            try
            {
                var res = _countryRepo.GetById(id);
                if (res != null)
                {
                    _logger.LogInformation("Return result");
                    return Ok(res);
                }
                else
                {
                    _logger.LogError("Error occured during get");
                    return StatusCode(500);
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.Message);
                return BadRequest();
            }
        }

        //Post
        [HttpPost(Name = "PostCountry")]
        public IActionResult Create([FromBody] CreateCountry createCountry)
        {
            try
            {
                var res = _countryRepo.Create(createCountry);
                if (res != 0)
                {
                    _logger.LogInformation("sucessfully created");
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        //Update
        [HttpPut(Name = "Update")]
        public IActionResult UpdateCountry(int id, UpadteCountry upadteCountry)
        {
            try
            {
                var res = _countryRepo.Update(id, upadteCountry);
                if (res != 0)
                {
                    _logger.LogInformation("sucessfully created");
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }
    }
}