using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MSDSHelper.DAL
{
    public interface IDao<T>
    {
        void Adicionar(T obj);
        void Delete(int id);
        void Update(T danger);
        T SelectByID(int id);
    }
}
