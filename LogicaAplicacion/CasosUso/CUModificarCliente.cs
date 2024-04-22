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
    public class CUModificarCliente : ICUModificar<Cliente>
    {
        public IRepositorioCliente Repo { get; set; }

        public CUModificarCliente(IRepositorioCliente repo)
        {
            Repo = repo;
        }
        public void Modificar(Cliente obj)
        {
            Repo.Update(obj);
        }
    }
}
