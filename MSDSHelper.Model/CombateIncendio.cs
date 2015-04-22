using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSDSHelper.Model
{
    public class CombateIncendio
    {
        private int _id;
        private string _meioApropriado;
        private string _perigoEspecifico;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string MeioApropriado
        {
            get { return _meioApropriado; }
            set { _meioApropriado = value; }
        }

        public string PerigoEspecifico
        {
            get { return _perigoEspecifico; }
            set { _perigoEspecifico = value; }
        }
    }
}
