using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorio <T>
    {
        void Add(T obj);
        void Remove(int id);
        void Update (T obj);
        List<T> FindAll();
        T FindById(int id);
    }
}
