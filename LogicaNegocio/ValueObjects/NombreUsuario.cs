using LogicaNegocio.ExcepcionPropias;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects
{
    [Owned]
    public class NombreUsuario
    {
        [StringLength(20)]
        public string Valor { get; init; }

        public NombreUsuario(string valor)
        {
            Valor = valor;
            Validar();
        }

        public NombreUsuario()
        {
        }

        private void Validar()
        {
            if (string.IsNullOrEmpty(Valor))
                throw new DatosInvalidosException("El nombre del autor es obligatorio");

            if (Valor.Length < 3)
                throw new DatosInvalidosException("El nombre del autor debe tener al memos 3 caracteres");
        }


        public override bool Equals(object? obj)
        {
            NombreUsuario otro = obj as NombreUsuario;
            if (otro == null) return false;
            return otro.Valor == Valor;
        }
    }
}
