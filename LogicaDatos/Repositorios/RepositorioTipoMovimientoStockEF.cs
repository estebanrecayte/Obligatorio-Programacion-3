﻿using LogicaNegocio.Dominio;
using LogicaNegocio.ExcepcionPropias;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioTipoMovimientoStockEF : IRepositorioTipoMovimientoStock
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioTipoMovimientoStockEF(LibreriaContext ctx)
        {
            Contexto = ctx;
        }
        public void Add(TipoMovimientoStock obj)
        {
            Contexto.TiposDeMovimiento.Add(obj);
            Contexto.SaveChanges();
        }

        public List<TipoMovimientoStock> FindAll()
        {
            return Contexto.TiposDeMovimiento.ToList();
        }

        public TipoMovimientoStock FindById(int id)
        {
            return Contexto.TiposDeMovimiento.Find(id);
        }

        public void Remove(int id)
        {
            var tipoMovimiento = Contexto.TiposDeMovimiento.Find(id);
            if (tipoMovimiento != null)
            {
                Contexto.TiposDeMovimiento.Remove(tipoMovimiento);
                Contexto.SaveChanges();
            }
            else
            {
                throw new ExcepcionPropiaException("No se encontró el tipo de movimiento.");
            }
        }

        public void Update(TipoMovimientoStock obj)
        {
            var tipoMovimiento = Contexto.TiposDeMovimiento.Find(obj.Id);
            if (tipoMovimiento != null)
            {
                tipoMovimiento.Nombre = obj.Nombre;
                tipoMovimiento.ModificaStock = obj.ModificaStock;
                Contexto.SaveChanges();
            }
            else
            {
                throw new ExcepcionPropiaException("No se encontró el tipo de movimiento.");
            }
        }
    }
}
