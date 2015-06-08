

using System;
using System.Globalization;

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

        /// <summary>
        /// Método responsavel por validar password do usuario com pelo menos 
        /// </summary>
        /// <returns></returns>
        public bool IsValidPassword(out string msgm)
        {
            if (Password == string.Empty)
                throw new Exception("Propriedade Password não foi inicializada.");
            if (Password.Length < 6)
            {
                msgm = "A senha não pode ser menor que 6 caracteres.";
                return false;
            }
            msgm = string.Empty;
            return true;
        }
    }
}
