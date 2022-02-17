using Microsoft.AspNetCore.Mvc;

namespace MyFirstCRUDapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeController : Controller
    {
        [HttpGet]
        public  async Task<ActionResult<List<employe>>> Get()
        {
            var employee = new List<employe>
            {
                new employe {
                    id = 1,
                    name ="jayce",
                    FirstName="jordan",
                    LastName="ok",
                    place="UK" 
                }
            };
            return Ok(employee);
        }
    }
}
