using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public int GetPermission(string login)
        {
            return _userDAO.GetPermission(login);
        }

    }
}
