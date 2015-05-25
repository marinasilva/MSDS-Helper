using System.Collections.Generic;
using MSDSHelper.DAL;
using MSDSHelper.Model;

namespace MSDSHelper.BLL
{
    public class UserBLL 
    {
        UserDAO _userDAO = new UserDAO();
        
        public bool ValidatePassword(string login, string password)
        {
            if (_userDAO.ValidePass(login) == password)
                return true;
            return false;
        }

        public User SelectByID(int id)
        {
            return _userDAO.SelectByID(id);
        }

        public List<User> SelectByName(string name)
        {
            return _userDAO.SelectByName(name);
        }

        public List<User> SelectByLogin(string login)
        {
            return _userDAO.SelectByLogin(login);
        }

        public User SelectLast()
        {
            return _userDAO.SelectLast();
        }

    }
}
