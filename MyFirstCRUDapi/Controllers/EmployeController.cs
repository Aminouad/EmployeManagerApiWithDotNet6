using Microsoft.AspNetCore.Mvc;

namespace MyFirstCRUDapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeController : Controller
    {
        
        private readonly DataContext context;

        public EmployeController(DataContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public  async Task<ActionResult<List<employe>>> Get()
        {
            
            return Ok(await context.Employe.ToListAsync());
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<employe>> Get(int id)
        {
            var employe =await context.Employe.FindAsync(id);
            if(employe == null)
            {
                return BadRequest("employee not found");
            }
            return Ok(employe);
        }
        [HttpPost]
        public async Task<ActionResult<List<employe>>> AddEmployee(employe emp)
        {
            context.Employe.Add(emp);
            await context.SaveChangesAsync();
            return Ok(await context.Employe.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<employe>>> UpdateEmployee(employe request)
        {
            var employe = await context.Employe.FindAsync(request.id);
            if (employe == null)
            {
                return BadRequest("employee not found");
            }
            employe.name = request.name;
            employe.FirstName = request.FirstName;
            employe.LastName = request.LastName;
            employe.place=request.place;    
           await context.SaveChangesAsync();
            return Ok(await context.Employe.ToListAsync());
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult<List<employe>>> Delete(int id)
        {
            var employe = await context.Employe.FindAsync(id);
            if (employe == null)
            {
                return BadRequest("employee not found");
            }
            context.Employe.Remove(employe);
            await context.SaveChangesAsync();

            return Ok(await context.Employe.ToListAsync());
        }
    }


}
