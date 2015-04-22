using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSDSHelper.Model
{
    public class User
    {
        private int _id;
        private string _nome;
        private string _login;
        private string _password;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
    }
}
