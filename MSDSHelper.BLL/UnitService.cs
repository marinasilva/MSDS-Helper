using System.Collections.Generic;
using MSDSHelper.DAL;
using MSDSHelper.Model;

namespace MSDSHelper.BLL
{
    public class UnitService : IBLL<Unit>
    {
        private readonly UnitDao _unitDao = new UnitDao();

        public void Adicionar(Unit unit)
        {
            _unitDao.Adicionar(unit);
        }

        public void Delete(int id)
        {
            _unitDao.Delete(id);
        }

        public void Update(Unit unit)
        {
            _unitDao.Update(unit);
        }

        public Unit SelectByID(int id)
        {
            return _unitDao.SelectByID(id);
        }

        public List<Unit> SelectAll()
        {
            return _unitDao.SelectAll();
        }

        public Unit SelectByName(string unit)
        {
            return _unitDao.SelectByName(unit);
        }
    }
}
