using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MSDSHelper.Model;

namespace MSDSHelper.DAL
{
    public class UnitDao : IDao<Unit>
    {
        private const string ADICIONAR = @"INSERT INTO Unit ([Unidade],[Sigla])   VALUES (@unidade,@sigla)";
        private const string DELETE = @"DELETE FROM UNIT WHERE IDUNIDADE = @idUnidade";
        private const string UPDATE = @"UPDATE Unit SET [Unidade] = @unidade, [Sigla] = @sigla WHERE idUnidade = @idUnidade";
        private const string SELECT_BY_ID = @"SELECT * FROM UNIT WHERE IDUNIDADE = @idUnidade";
        private const string SELECT_ALL = @"SELECT * FROM UNIT";
        private const string SELECT_BY_NAME = @"SELECT * FROM UNIT WHERE UNIDADE = @Unidade";

        public void Adicionar(Unit unit)
        {
            SqlConnection connection = ContextFactory.Instancia();
            using (SqlCommand command = new SqlCommand(ADICIONAR, connection))
            {
                command.Parameters.AddWithValue("@unidade", unit.Unidade);
                command.Parameters.AddWithValue("@sigla", unit.Sigla);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            SqlConnection connection = ContextFactory.Instancia();
            using (SqlCommand command = new SqlCommand(DELETE, connection))
            {
                command.Parameters.AddWithValue("idUnidade", id);
                command.ExecuteNonQuery();
            }
        }

        public void Update(Unit danger)
        {
            SqlConnection connection = ContextFactory.Instancia();
            using (SqlCommand command = new SqlCommand(UPDATE, connection))
            {
                command.Parameters.AddWithValue("@unidade", danger.Unidade);
                command.Parameters.AddWithValue("@sigla", danger.Sigla);
                command.Parameters.AddWithValue("@idUnidade", danger.Id);
                command.ExecuteNonQuery();
            }
        }

        public Unit SelectByID(int id)
        {
            SqlConnection connection = ContextFactory.Instancia();
            Unit unit;
            using (SqlCommand command = new SqlCommand(SELECT_BY_ID, connection))
            {
                command.Parameters.AddWithValue("@idUnidade", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    unit = null;
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
                }
            }
            return unit;
        }

        public List<Unit> SelectAll()
        {
            SqlConnection connection = ContextFactory.Instancia();
            List<Unit> unitList;
            using (SqlCommand command = new SqlCommand(SELECT_ALL, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    unitList = new List<Unit>();
                    Unit unit = null;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            unit = new Unit();
                            unit.Id = Convert.ToInt32(reader["idUnidade"]);
                            unit.Unidade = reader["Unidade"] == DBNull.Value ? string.Empty : reader["Unidade"].ToString();
                            unit.Sigla = reader["Sigla"] == DBNull.Value ? string.Empty : reader["Sigla"].ToString();
                            unitList.Add(unit);
                        }
                    }
                }
            }
            return unitList;
        }

        public Unit SelectByName(string unit)
        {
            SqlConnection connection = ContextFactory.Instancia();
            Unit _unit = null;
            using (SqlCommand command = new SqlCommand(SELECT_BY_NAME, connection))
            {
                command.Parameters.AddWithValue("@Unidade", unit);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            _unit = new Unit();
                            _unit.Id = Convert.ToInt32(reader["idUnidade"]);
                            _unit.Unidade = reader["Unidade"] == DBNull.Value
                                ? string.Empty
                                : reader["Unidade"].ToString();
                            _unit.Sigla = reader["Sigla"] == DBNull.Value ? string.Empty : reader["Sigla"].ToString();
                        }
                    }
                }
            }
            return _unit;
        }
    }
}
