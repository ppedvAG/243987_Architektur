using Microsoft.AspNetCore.Mvc;
using ppedv.CrustControl.Model.Contracts;
using ppedv.CrustControl.Model.DomainModel;

namespace ppedv.CrustControl.Web.MVC.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IRepository repo;

        public PizzaController(IRepository repo)
        {
            this.repo = repo;
        }

        // GET: PizzaController
        public ActionResult Index()
        {
            var pizzas = repo.Query<Pizza>().ToList();
            return View(pizzas);
        }

        // GET: PizzaController/Details/5
        public ActionResult Details(int id)
        {
            return View(repo.GetById<Pizza>(id));
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
                repo.Add(pizza);
                repo.SaveAll();
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
            return View(repo.GetById<Pizza>(id));
        }

        // POST: PizzaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Pizza pizza)
        {
            try
            {
                repo.Update(pizza);
                repo.SaveAll();
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
            return View(repo.GetById<Pizza>(id));
        }

        // POST: PizzaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Pizza pizza)
        {
            try
            {
                repo.Delete(pizza);
                repo.SaveAll();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
