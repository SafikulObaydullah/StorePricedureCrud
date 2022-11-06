using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;

namespace storedProceedureCurd.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class DivisionController : ControllerBase
   {
      private readonly IDivisionRepo _divisionRepo;
      private readonly ILogger<DivisionController> _logger;
      public DivisionController(IDivisionRepo divisionRepo, ILogger<DivisionController> logger)
      {
         _divisionRepo = divisionRepo;
         _logger = logger; 
      }
      [HttpGet(Name = "GetAlls")]
      public IActionResult GetAll()
      {
         try
         {
            var res = _divisionRepo.GetAll();
            if(res.Count != 0)
            {
               _logger.LogInformation($"Total {res.Count} Division returned");
               return Ok(res);
            }
            else
            {
               _logger.LogInformation($"Error occured when get All");
               return BadRequest();
            }
         }
         catch(Exception ex)
         {
            _logger.LogError(ex.Message);
            return BadRequest(ex.Message);
         }
      }
   }
}
