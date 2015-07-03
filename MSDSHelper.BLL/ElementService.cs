using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSDSHelper.DAL;
using MSDSHelper.Model;

namespace MSDSHelper.BLL
{
    public class ElementService : IBLL<Element>
    {
        private readonly ElementDao _elementDao = new ElementDao();
       
        public void Adicionar(Element element)
        {
         _elementDao.Adicionar(element);   
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Element element)
        {
            _elementDao.Update(element);     
        }
       
        public Element SelectByID(int id)
        {
            return _elementDao.SelectByID(id);
        }

        public List<Element> SelectByName(string name)
        {
            return _elementDao.SelectByName(name);
        }

        public List<Element> SelectByFormula(string formula)
        {
            return _elementDao.SelectByFormula(formula);
        }

        public Element SelectLast()
        {
            return _elementDao.SelectLast();
        }

        public List<Element> SelectByFabricante(string fabricante)
        {
            return _elementDao.SelectByFabricante(fabricante);
        }

        public int SelectCount()
        {
            return _elementDao.SelectCount();
        }
    }
}
