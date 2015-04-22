using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using MSDSHelper.Model;

namespace MSDSHelper.DAL
{
    public class CombateIncendioDAO : IDAO<CombateIncendio>
    {
        private const string _adicionar = @"INSERT INTO CombateIncendio  ([MeioApropriado],[PerigoEspecifico]) VALUES (@meioApropriado, @perigoEspecifico)";
        
        public void Adicionar(CombateIncendio combateIncendio)
        {
            SqlConnection connection = ContextFactory.Instancia();
            SqlCommand command = new SqlCommand(_adicionar, connection);
            command.Parameters.AddWithValue("@meioApropriado", combateIncendio.MeioApropriado);
            command.Parameters.AddWithValue("@perigoEspecifico", combateIncendio.PerigoEspecifico);
            command.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }

        public CombateIncendio SelectByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
