using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using MSDSHelper.Model;

namespace MSDSHelper.DAL
{
    public class UnitDAO : IDAO<Unit>
    {
        private const string _adicionar = @"INSERT INTO Unit ([Unidade],[Sigla])   VALUES (@unidade,@sigla)";
        private const string _delete = @"DELETE FROM UNIT WHERE IDUNIDADE = @idUnidade";
        private const string _update = @"UPDATE Unit SET [Unidade] = @unidade, [Sigla] = @sigla WHERE idUnidade = @idUnidade";
        private const string _selectByID = @"SELECT * FROM UNIT WHERE IDUNIDADE = @idUnidade";

        public void Adicionar(Unit unit)
        {
            SqlConnection connection = ContextFactory.Instancia();
            SqlCommand command = new SqlCommand(_adicionar, connection);
            command.Parameters.AddWithValue("@unidade", unit.Unidade);
            command.Parameters.AddWithValue("@sigla", unit.Sigla);
            command.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlConnection connection = ContextFactory.Instancia();
            SqlCommand command = new SqlCommand(_delete, connection);
            command.Parameters.AddWithValue("idUnidade", id);
            command.ExecuteNonQuery();
        }

        public void Update(Unit unit)
        {
            SqlConnection connection = ContextFactory.Instancia();
            SqlCommand command = new SqlCommand(_update, connection);
            command.Parameters.AddWithValue("@unidade", unit.Unidade);
            command.Parameters.AddWithValue("@sigla", unit.Sigla);
            command.Parameters.AddWithValue("@idUnidade", unit.Id);
            command.ExecuteNonQuery();
        }

        public Unit SelectByID(int id)
        {
            SqlConnection connection = ContextFactory.Instancia();
            SqlCommand command = new SqlCommand(_selectByID, connection);
            command.Parameters.AddWithValue("@idUnidade", id);
            SqlDataReader reader = command.ExecuteReader();
            Unit unit = null;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    unit = new Unit();
                    unit.Id = Convert.ToInt32(reader["idUnidade"]);
                    unit.Unidade = reader["Unidade"] == DBNull.Value ? string.Empty : reader["Unidade"].ToString();
                    unit.Sigla = reader["Sigla"] == DBNull.Value ? string.Empty : reader["Sigla"].ToString();
                }   
            }
            return unit;
        }
    }
}
