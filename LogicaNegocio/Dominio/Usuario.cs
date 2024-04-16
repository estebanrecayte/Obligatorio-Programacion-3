using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    [Table("Usuarios")]
    public class Usuario:IValidable
    {
        public int Id { get; set; }
        public static int UltId { get; set; } = 0;
        public string Email { get; set; }
        [StringLength(20,MinimumLength = 3,ErrorMessage = "El nombre debe tener al menos 3 caracteres")]
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Password { get; set; }

        public Usuario()
        {
            Id = UltId++;
        }

        public void EsValido()
        {
            // Falta validar cuando un usuario es valido
        }
    }
}
