using System.ComponentModel.DataAnnotations;

namespace Libreria_MVC.Models
{
    public class LoginViewModel
    {
        public string Mail { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
