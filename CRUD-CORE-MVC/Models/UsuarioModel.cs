//using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;


namespace CRUD_CORE_MVC.Models
{
    public class UsuarioModel
    {

        public int idUsuario { get; set; }

        [Required(ErrorMessage="*Campo requerido")]
        public string? User { get; set; }

        [Required(ErrorMessage = "*Campo requerido")]
        public string? Contraseña { get; set; }
        public bool tipoUser { get; set; }
    }
}
