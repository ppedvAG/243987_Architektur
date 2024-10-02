using Microsoft.AspNetCore.Mvc;
using ppedv.CrustControl.Model.Contracts.Data;
using ppedv.CrustControl.Model.DomainModel;

namespace ppedv.CrustControl.Web.MVC.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IUnitOfWork _uow;

        public PizzaController(IUnitOfWork repo)
        {
            this._uow = repo;
        }

        // GET: PizzaController
        public ActionResult Index()
        {
            var pizzas = _uow.PizzaRepo.Query().ToList();
            return View(pizzas);
        }

        // GET: PizzaController/Details/5
        public ActionResult Details(int id)
        {
            return View(_uow.PizzaRepo.GetById(id));
        }

        // GET: PizzaController/Create
        public ActionResult Create()
        {
            return View(new Pizza() { Name = "NEU" });
        }

        // POST: PizzaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pizza pizza)
        {
            try
            {
                _uow.PizzaRepo.Add(pizza);
                _uow.SaveAll();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PizzaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_uow.PizzaRepo.GetById(id));
        }

        // POST: PizzaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Pizza pizza)
        {
            try
            {
                _uow.PizzaRepo.Update(pizza);
                _uow.SaveAll();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PizzaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_uow.PizzaRepo.GetById(id));
        }

        // POST: PizzaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Pizza pizza)
        {
            try
            {
                _uow.PizzaRepo.Delete(pizza);
                _uow.SaveAll();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
