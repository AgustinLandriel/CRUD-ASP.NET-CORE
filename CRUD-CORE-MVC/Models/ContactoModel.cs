//using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;


namespace CRUD_CORE_MVC.Models
{
    public class ContactoModel
    {
        public int idContacto { get; set; }

        [Required(ErrorMessage ="*Nombre es obligatorio")] //Para validar el campo
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "*Telefono es obligatorio")]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "*Email es obligatorio")]
        public string? Correo { get; set; }

    }
}
