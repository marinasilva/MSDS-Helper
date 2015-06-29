using System;
using MSDSHelper.DAL;
using MSDSHelper.Model;

namespace MSDSHelper.BLL
{
    public class CombateIncendioService : IBLL<CombateIncendio>
    {
        readonly CombateIncendioDao _combate = new CombateIncendioDao();
        
        public void Adicionar(CombateIncendio combateIncendio)
        {
            _combate.Adicionar(combateIncendio);
        }

        public void Delete(int id)
        {
           _combate.Delete(id);
        }

        public void Update(CombateIncendio combateIncendio)
        {
            _combate.Update(combateIncendio);
        }

        public CombateIncendio SelectByID(int id)
        {
            return _combate.SelectByID(id);
        }

        public CombateIncendio SelectLast()
        {
            return _combate.SelectLast();
        }
    }
}
