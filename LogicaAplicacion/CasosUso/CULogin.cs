using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CULogin : ICULogin
    {
        public IRepositorioUsuario Repo { get; set; }

        public CULogin(IRepositorioUsuario repo)
        {
            Repo = repo;
        }
        public bool UsuarioCorrecto(string mail, string password)
        {
            Usuario usuarioBuscado = Repo.BuscarUsuarioPorMail(mail);
            if (usuarioBuscado != null && usuarioBuscado.VerifyPassword(password))
            {
                return true;
            }
            return false;
        }

        
    }
}
