﻿using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUBajaUsuario : ICUBaja<Usuario>
    {
        public IRepositorioUsuario Repo { get; set; }

        public CUBajaUsuario(IRepositorioUsuario repo)
        {
            Repo = repo;
        }
        public void Baja(int id)
        {
            Repo.Remove(id);
        }
    }
}
