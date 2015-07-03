using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSDSHelper.DAL;
using MSDSHelper.Model;

namespace MSDSHelper.BLL
{
    public class DangerService : IBLL<Danger>
    {
        private readonly DangerDao _danger = new DangerDao();

        public void Adicionar(Danger obj)
        {
            _danger.Adicionar(obj);
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
