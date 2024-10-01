using Microsoft.AspNetCore.Mvc;
using ppedv.CrustControl.Model.Contracts;
using ppedv.CrustControl.Model.DomainModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ppedv.CrustControl.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IRepository repo;

        public PizzaController(IRepository repo)
        {
            this.repo = repo;
        }

        // GET: api/<PizzaController>
        [HttpGet]
        public IEnumerable<Pizza> Get()
        {
            return repo.Query<Pizza>().ToList();
        }

        // GET api/<PizzaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PizzaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PizzaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PizzaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
