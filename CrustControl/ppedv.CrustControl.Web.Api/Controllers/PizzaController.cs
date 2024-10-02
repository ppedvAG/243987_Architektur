using Microsoft.AspNetCore.Mvc;
using ppedv.CrustControl.Model.Contracts.Data;
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
        private readonly IUnitOfWork _uow;
        private readonly PizzaMapper mapper = new PizzaMapper();

        public PizzaController(IUnitOfWork repo)
        {
            this._uow = repo;
        }

        // GET: api/<PizzaController>
        [HttpGet]
        public IEnumerable<PizzaDTO> Get()
        {
            foreach (var item in _uow.PizzaRepo.Query().ToList())
            {
                yield return mapper.MapToDTO(item);
            }
        }

        // GET api/<PizzaController>/5
        [HttpGet("{id}")]
        public ActionResult<PizzaDTO> Get(int id)
        {
            var pizza = _uow.PizzaRepo.GetById(id);

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
            _uow.PizzaRepo.Add(pizza);
            _uow.SaveAll();
        }

        // PUT api/<PizzaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PizzaDTO value)
        {
            ArgumentNullException.ThrowIfNull(value);

            var pizza = mapper.MapToEntity(value);
            _uow.PizzaRepo.Update(pizza);
            _uow.SaveAll();
        }

        // DELETE api/<PizzaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var pizza = _uow.PizzaRepo.GetById(id);
            if (pizza == null)
                return NotFound($"Pizza wir ID {id} wurde nicht gefunden.");
            _uow.PizzaRepo.Delete(pizza);
            _uow.SaveAll();

            return Ok();
        }
    }
}
