using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSDSHelper.Model
{
    public class Danger
    {
        private int _id;
        private string _descricao;
        private string _inalacao;
        private string _contatoOlhos;
        private string _contatoPele;
        private string _ingestao;
        private CombateIncendio _combateIncendio;

        public Danger()
        {
            _combateIncendio = new CombateIncendio();
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Inalacao
        {
            get { return _inalacao; }
            set { _inalacao = value; }
        }

        public string ContatoOlhos
        {
            get { return _contatoOlhos; }
            set { _contatoOlhos = value; }
        }

        public string ContatoPele
        {
            get { return _contatoPele; }
            set { _contatoPele = value; }
        }

        public string Ingestao
        {
            get { return _ingestao; }
            set { _ingestao = value; }
        }

        public CombateIncendio Incendio
        {
            get { return _combateIncendio; }
            set { _combateIncendio = value; }
        }

        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }
    }
}
