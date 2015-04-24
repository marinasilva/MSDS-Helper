using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSDSHelper.Model
{
    public class Unit
    {
        private int _id;
        private string _unidade;
        private string _sigla;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Unidade
        {
            get { return _unidade; }
            set { _unidade = value; }
        }

        public string Sigla
        {
            get { return _sigla; }
            set { _sigla = value; }
        }
    }
}
