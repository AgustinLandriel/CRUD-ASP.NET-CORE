using Microsoft.AspNetCore.Mvc;
using CRUD_CORE_MVC.AccesoDatos;
using CRUD_CORE_MVC.Models;
using NuGet.Packaging.Rules;
using System.Diagnostics.Contracts;

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
        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ContactoModel contacto)
        {
            if (!ModelState.IsValid) // Si no se valida el modelo devuelvo la vista
            {
                return View();
            }

            //Se crea un contacto nuevo
             bool respuesta = datos.AgregarContacto(contacto);
                
            if (respuesta) // Si se agrega el contacto, redirecciono a la view listar.
            {
               return RedirectToAction("Listar"); 

            } else
            {
                return View();
            }
        }

        public IActionResult Editar( int idContacto)
        {
            var contacto = datos.ObtenerContacto(idContacto);
            return View(contacto);
        }

        [HttpPost]
        public IActionResult Editar(ContactoModel contacto)
        {

            if (!ModelState.IsValid) // Si no se valida el modelo devuelvo la vista
            {
                return View();
            }

            //Se crea un contacto nuevo
            
            bool respuesta = datos.ModificarContacto(contacto);

            if (respuesta) // Si se agrega el contacto, redirecciono a la view listar.
            {
                return RedirectToAction("Listar");

            }
            else
            {
                return View();
            }
        }


        public IActionResult Eliminar(int idContacto)
        {
            var contacto = datos.ObtenerContacto(idContacto);
            return View(contacto);
        }

        [HttpPost]
        public IActionResult Eliminar(ContactoModel contacto )
        {
            bool respuesta = datos.EliminarContacto(contacto.idContacto);

            if (respuesta) 
            {
                return RedirectToAction("Listar");

            }
            else
            {
                return View();
            }
        }

    }
}
