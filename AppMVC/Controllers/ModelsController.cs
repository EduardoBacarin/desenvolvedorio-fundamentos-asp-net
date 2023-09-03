using AppMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppMVC.Controllers
{
    public class ModelsController : Controller
    {
        public IActionResult Index()
        {
            var aluno = new Aluno();

            /* Verifica se o input é válido na model, returna true ou false */
            if (TryValidateModel(aluno))
            {
                return View(aluno);
            }

            var ms = ModelState;

            return View();
        }
    }
}
