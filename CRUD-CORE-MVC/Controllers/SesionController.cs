using CRUD_CORE_MVC.Models;
using CRUD_CORE_MVC.AccesoDatos;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_CORE_MVC.Controllers
{
	public class SesionController : Controller
	{
		public IActionResult Registro()
		{
			return View();
		}

        [HttpPost]
        public IActionResult Registro(UsuarioModel usuario)
        {
            Registro registro = new Registro();

            if (!ModelState.IsValid) // Si no se valida el modelo devuelvo la vista
            {
                return View();
            }

            bool respuesta = registro.UsuarioRegistro(usuario);

            if (respuesta) // Si respuesta es true es porque se creo el user
            {
                return RedirectToAction("Listar","Contacto");
            }
            else
            {
                return View();
            }
            
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UsuarioModel usuario)
        {
            Registro registro = new Registro();

            if (!ModelState.IsValid) // Si no se valida el modelo devuelvo la vista
            {
                return View();
            }

            bool respuesta = registro.BuscarUsuario(usuario);

            if (respuesta) // Si respuesta es true es porque se creo el user
            {
                return RedirectToAction("Listar", "Contacto");
            }
            else
            {
                return View();
            }

            
        }
    }
}
