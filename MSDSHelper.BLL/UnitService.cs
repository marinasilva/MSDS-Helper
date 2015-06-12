using System.Collections.Generic;
using MSDSHelper.DAL;
using MSDSHelper.Model;

namespace MSDSHelper.BLL
{
    public class UnitService : IBLL<Unit>
    {
        private UnitDAO _unitDAO = new UnitDAO();
        
        public void Adicionar(Unit unit)
        {
            _unitDAO.Adicionar(unit);
        }

        public void Delete(int id)
        {
            _unitDAO.Delete(id);
        }

        public void Update(Unit unit)
        {
            _unitDAO.Update(unit);
        }

        public Unit SelectByID(int id)
        {
            return _unitDAO.SelectByID(id); 
        }

        public List<Unit> SelectAll()
        {
            return _unitDAO.SelectAll();
        }

        public Unit SelectByName(string unit)
        {
            return _unitDAO.SelectByName(unit);
        }
    }
}
