using Microsoft.AspNetCore.Mvc;
using CRUD_CORE_MVC.AccesoDatos;
using CRUD_CORE_MVC.Models;

namespace CRUD_CORE_MVC.Controllers
{
    public class ContactoController : Controller
    {
        ContactoDatos datos = new ContactoDatos();

        public IActionResult Listar()
        {
            //Se muestra la lista de contactos
            
           var lista = datos.ListarContacto();

            return View(lista);
        }

        [HttpPost]
        public IActionResult Guardar(ContactoModel contacto)
        {
            //Se crea un contacto nuevo
            datos.AgregarContacto(contacto);

            //Redirecciono a la pagina listar
            RedirectToAction("Listar"); // Es como el Response.Redirect en web forms
            return View();
        }

        
        public IActionResult Modificar()
        {
            return View();
        }
    }
}
