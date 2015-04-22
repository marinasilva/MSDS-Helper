using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MSDSHelper.DAL
{
    public interface IDAO<T>
    {
        void Adicionar(T obj);
        void Delete(int id);
        void Update(int id);
        T SelectByID(int id);
    }
}
