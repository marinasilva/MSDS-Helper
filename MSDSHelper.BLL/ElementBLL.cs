﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSDSHelper.DAL;
using MSDSHelper.Model;

namespace MSDSHelper.BLL
{
    public class ElementBLL : IBLL<Element>
    {
        ElementDAO _elementDAO = new ElementDAO();
        private Element _element = null;

        public void Adicionar(Element element)
        {
         _elementDAO.Adicionar(element);   
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }

        public Element SelectByID(int id)
        {
            return _elementDAO.SelectByID(id);
        }

        public List<Element> SelectByName(string name)
        {
            return _elementDAO.SelectByName(name);
        }

        public List<Element> SelectByFormula(string formula)
        {
            return _elementDAO.SelectByFormula(formula);
        }
    }
}