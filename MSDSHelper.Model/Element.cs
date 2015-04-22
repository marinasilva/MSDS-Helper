using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSDSHelper.Model
{
    public class Element
    {
        private int _id;
        private string _nomeProduto;
        private string _formulaMolecular;
        private int _pesoMolecular;
        private string _unidade;
        private string _fabricante;
        private string _descricao;
        private Danger _danger;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string NomeProduto
        {
            get { return _nomeProduto; }
            set { _nomeProduto = value; }
        }

        public string FormulaMolecular
        {
            get { return _formulaMolecular; }
            set { _formulaMolecular = value; }
        }

        public int PesoMolecular
        {
            get { return _pesoMolecular; }
            set { _pesoMolecular = value; }
        }

        public string Unidade
        {
            get { return _unidade; }
            set { _unidade = value; }
        }

        public string Fabricante
        {
            get { return _fabricante; }
            set { _fabricante = value; }
        }

        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

        public Danger Danger
        {
            get { return _danger; }
            set { _danger = value; }
        }
    }
}
