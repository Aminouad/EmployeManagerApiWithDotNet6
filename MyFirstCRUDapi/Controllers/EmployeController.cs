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
                },
                new employe {
                    id = 2,
                    name ="john keny",
                    FirstName="john",
                    LastName="keny",
                    place="US"
                }
            };
        [HttpGet]
        public  async Task<ActionResult<List<employe>>> Get()
        {
            
            return Ok(employes);
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<employe>> Get(int id)
        {
            var employe = employes.Find(e=> e.id==id);
            if(employe == null)
            {
                return BadRequest("employee not found");
            }
            return Ok(employe);
        }
        [HttpPost]
        public async Task<ActionResult<List<employe>>> AddEmployee(employe emp)
        {
            employes.Add(emp);
            return Ok(employes);
        }
        [HttpPut]
        public async Task<ActionResult<List<employe>>> UpdateEmployee(employe request)
        {
            var employe = employes.Find(e => e.id == request.id);
            if (employe == null)
            {
                return BadRequest("employee not found");
            }
            employe.name = request.name;
            employe.FirstName = request.FirstName;
            employe.LastName = request.LastName;
            employe.place=request.place;    
            return Ok(employes);
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult<List<employe>>> Delete(int id)
        {
            var employe = employes.Find(e => e.id == id);
            if (employe == null)
            {
                return BadRequest("employee not found");
            }
            employes.Remove(employe);
            return Ok(employes);
        }
    }


}
