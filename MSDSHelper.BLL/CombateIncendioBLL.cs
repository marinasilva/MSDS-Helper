using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSDSHelper.DAL;
using MSDSHelper.Model;

namespace MSDSHelper.BLL
{
    public class CombateIncendioBLL : IBLL<CombateIncendio>
    {
        CombateIncendioDAO _combate = new CombateIncendioDAO();
        
        public void Adicionar(CombateIncendio obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CombateIncendio combateIncendio)
        {
            _combate.Update(combateIncendio);
        }

        public CombateIncendio SelectByID(int id)
        {
            throw new NotImplementedException();
        }

        public CombateIncendio SelectLast()
        {
            return _combate.SelectLast();
        }
    }
}
