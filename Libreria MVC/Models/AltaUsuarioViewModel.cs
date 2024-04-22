using LogicaNegocio.Dominio;
using LogicaNegocio.ValueObjects;

namespace Libreria_MVC.Models
{
    public class AltaUsuarioViewModel
    {
       
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Password { get; set; }
    }
}
