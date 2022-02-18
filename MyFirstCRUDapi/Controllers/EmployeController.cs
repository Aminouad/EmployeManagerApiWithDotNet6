using Microsoft.AspNetCore.Mvc;

namespace MyFirstCRUDapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeController : Controller
    {
        private static List<employe> employes = new List<employe>
            {
                new employe {
                    id = 1,
                    name ="jayce",
                    FirstName="jordan",
                    LastName="ok",
                    place="UK"
                }
            };
        [HttpGet]
        public  async Task<ActionResult<List<employe>>> Get()
        {
            
            return Ok(employes);
        }
        [HttpPost]
        public async Task<ActionResult<List<employe>>> AddEmployee(employe emp)
        {
            employes.Add(emp);
            return Ok(employes);
        }
    }


}
