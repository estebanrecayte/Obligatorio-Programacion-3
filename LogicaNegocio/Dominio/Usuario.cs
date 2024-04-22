using LogicaNegocio.ExcepcionPropias;
using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    [Table("Usuarios")]
    public class Usuario:IValidable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
     
        
        [EmailAddress]
        public string Email { get; set; }
        public NombreUsuario Nombre { get; set; }
        public string Apellido { get; set; }
        public string Password { get; set; }

        public Usuario()
        {
          
        }

        public void EsValido()
        {
            if (!string.IsNullOrEmpty(Nombre.Valor))
            {
                var regex = new Regex(@"^[a-zA-Z][a-zA-Z\s'-]*[a-zA-Z]$"); // comienzo de cadena valores alfabeticos [a - z], [a-zA-Z\s'-]* en el medio de cadena pueden haber otros caracteres y [a-zA-Z]$ al final solo valores alfabeticos. 
                if (!regex.IsMatch(Nombre.Valor))
                {
                    throw new DatosInvalidosException("El nombre solo puede contener caracteres alfabéticos, espacio, apóstrofe o guión del medio.");
                }
            }

            if (!string.IsNullOrEmpty(Apellido))
            {
                var regex = new Regex(@"^[a-zA-Z][a-zA-Z\s'-]*[a-zA-Z]$");
                if (!regex.IsMatch(Apellido))
                {
                    throw new DatosInvalidosException("El apellido solo puede contener caracteres alfabéticos, espacio, apóstrofe o guión del medio.");
                }
            }

            if (!string.IsNullOrEmpty(Password))
            {
                if (Password.Length < 6)
                {
                    throw new DatosInvalidosException("La contraseña debe tener al menos 6 caracteres.");
                }


                var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[.,;!])(?=.*[^\w\d\s]).{6,}$");

                //Tener al menos una letra mayúscula((?=.* [A - Z])).
                //Tener al menos una letra minúscula((?=.* [a - z])).
                //Tener al menos un dígito((?=.*\d)).
                //Tener al menos un carácter de puntuación((?=.* [.,; !])).
                //No contener caracteres no alfanuméricos((?=.* [^\w\d\s])).
                //Tener una longitud mínima de 6 caracteres(.{ 6,}).

                if (!regex.IsMatch(Password))
                {
                    throw new DatosInvalidosException("La contraseña debe contener al menos una letra mayúscula, una minúscula, un dígito y un carácter de puntuación y tener al menos 6 caracteres de longitud.");
                }
            }

        }
    }
}
