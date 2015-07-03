using System.Collections.Generic;
using MSDSHelper.DAL;
using MSDSHelper.Model;

namespace MSDSHelper.BLL
{
    public class UserService 
    {
        readonly UserDao _userDao = new UserDao();
        
        public bool ValidatePassword(string login, string password)
        {
            if (_userDao.ValidePass(login) == password)
                return true;
            return false;
        }

        public User SelectByID(int id)
        {
            return _userDao.SelectByID(id);
        }

        public List<User> SelectByName(string name)
        {
            return _userDao.SelectByName(name);
        }

        public List<User> SelectByLogin(string login)
        {
            return _userDao.SelectByLogin(login);
        }

        public User SelectLast()
        {
            return _userDao.SelectLast();
        }

        public void Adicionar(User user)
        {
            _userDao.Adicionar(user);
        }

        public int SelectIdentCurrent()
        {
            return _userDao.SelectIdentCurrent();
        }

        public void Update(User user)
        {
            _userDao.Update(user);
        }
    }
}
