using Microsoft.AspNetCore.Mvc;

namespace BarbeariaMVC.Controllers
{
    public class FuncionarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
