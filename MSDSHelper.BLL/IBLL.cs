using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSDSHelper.BLL
{
    interface IBLL<T>
    {
        void Adicionar(T obj);
        void Delete(int id);
        void Update( T obj);
        T SelectByID(int id);
    }
}
