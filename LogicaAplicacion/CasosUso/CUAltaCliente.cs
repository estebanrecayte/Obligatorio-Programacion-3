using DTOs;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaDatos.Repositorios;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUAltaCliente : ICUAlta<ClienteDTO>
    {
        public IRepositorioCliente Repo { get; set; }

        public CUAltaCliente(IRepositorioCliente repo)
        {
            Repo = repo;
        }

        public void Alta(ClienteDTO obj)
        {
            Cliente nuevo = MapperCliente.ToCliente(obj);
            Repo.Add(nuevo);
        }
    }
}
