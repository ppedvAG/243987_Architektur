using Microsoft.AspNetCore.Mvc;
using ppedv.CrustControl.Model.Contracts;
using ppedv.CrustControl.Model.DomainModel;
using ppedv.CrustControl.Web.Api.Mapper;
using ppedv.CrustControl.Web.Api.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ppedv.CrustControl.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IRepository repo;
        private readonly PizzaMapper mapper = new PizzaMapper();

        public PizzaController(IRepository repo)
        {
            this.repo = repo;
        }

        // GET: api/<PizzaController>
        [HttpGet]
        public IEnumerable<PizzaDTO> Get()
        {
            foreach (var item in repo.Query<Pizza>().ToList())
            {
                yield return mapper.MapToDTO(item);
            }
        }

        // GET api/<PizzaController>/5
        [HttpGet("{id}")]
        public ActionResult<PizzaDTO> Get(int id)
        {
            var pizza = repo.GetById<Pizza>(id);

            if (pizza == null)
                return NotFound();
                
            return mapper.MapToDTO(pizza);
        }

        // POST api/<PizzaController>
        [HttpPost]
        public void Post([FromBody] PizzaDTO value)
        {
            ArgumentNullException.ThrowIfNull(value);

            var pizza = mapper.MapToEntity(value);
            repo.Add(pizza);
            repo.SaveAll();
        }

        // PUT api/<PizzaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PizzaDTO value)
        {
            ArgumentNullException.ThrowIfNull(value);

            var pizza = mapper.MapToEntity(value);
            repo.Update(pizza);
            repo.SaveAll();
        }

        // DELETE api/<PizzaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var pizza = repo.GetById<Pizza>(id);
            if (pizza == null)
                return NotFound($"Pizza wir ID {id} wurde nicht gefunden.");
            repo.Delete(pizza);
            repo.SaveAll();

            return Ok();
        }
    }
}
