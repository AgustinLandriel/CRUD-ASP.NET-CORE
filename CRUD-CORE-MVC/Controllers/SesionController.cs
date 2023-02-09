using Microsoft.AspNetCore.Mvc;

namespace CRUD_CORE_MVC.Controllers
{
	public class SesionController : Controller
	{
		public IActionResult Registro()
		{
			return View();
		}
        public IActionResult Login()
        {
            return View();
        }
    }
}
