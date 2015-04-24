using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSDSHelper.DAL;
using MSDSHelper.Model;

namespace MSDSHelper.BLL
{
    public class DangerBLL : IBLL<Danger>
    {
        private DangerDAO _danger = new DangerDAO();

        public void Adicionar(Danger obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Danger danger)
        {
           _danger.Update(danger);
        }

        public Danger SelectByID(int id)
        {
            throw new NotImplementedException();
        }

        public Danger SelectLast()
        {
            return _danger.SelectLast();
        }
    }
}
