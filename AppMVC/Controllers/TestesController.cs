using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppMVC.Controllers
{
    [Route("minha-conta")]
    public class TestesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Route("details/{id:int}")]
        public ActionResult Details(int id)
        {
            return View();
        }

        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestesController/Create
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TestesController/Edit/5
        [Route("edit/{id:int}")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost("update")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost("delete/{id:int}")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
