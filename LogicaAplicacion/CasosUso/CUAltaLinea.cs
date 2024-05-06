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
    public class CUAltaLinea : ICUAlta<Linea>
    {
        public IRepositorioLinea Repo { get; set; }

        public CUAltaLinea (IRepositorioLinea repo)
        {
            Repo = repo;
        }

        public void Alta(Linea obj)
        {
            Repo.Add(obj);
        }
    }
}
