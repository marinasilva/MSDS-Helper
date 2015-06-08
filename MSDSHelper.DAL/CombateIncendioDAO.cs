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

        private const string _selectLast = @"SELECT TOP 1 FROM COMBATEINCENDIO ORDER BY idIncendio";

        private const string _update = @"UPDATE CombateIncendio SET [MeioApropriado] = @meioApropriado, [PerigoEspecifico] = @perigoEspecifico WHERE idIncendio = @idIncendio";

        private const string _delete = @"DELETE FROM COMBATEINCENDIO WHERE IDINCENDIO = @idIncendio";

        public void Adicionar(CombateIncendio combateIncendio)
        {
            SqlConnection connection = ContextFactory.Instancia();
            using (SqlCommand command = new SqlCommand(_adicionar, connection))
            {
                command.Parameters.AddWithValue("@meioApropriado", combateIncendio.MeioApropriado);
                command.Parameters.AddWithValue("@perigoEspecifico", combateIncendio.PerigoEspecifico);
                command.ExecuteNonQuery();
            }
        }

        public CombateIncendio SelectLast()
        {
            SqlConnection connection = ContextFactory.Instancia();
            CombateIncendio _combate;
            using (SqlCommand command = new SqlCommand(_selectLast, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    _combate = null;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            _combate = new CombateIncendio();
                            _combate.Id = Convert.ToInt32(reader["idIncendio"]);
                            _combate.MeioApropriado = reader["MeioApropriado"].ToString();
                            _combate.PerigoEspecifico = reader["PerigoEspecifico"].ToString();
                        }
                    }
                }
            }
            return _combate;
        }

        public void Delete(int id)
        {
            SqlConnection connection = ContextFactory.Instancia();
            using (SqlCommand command = new SqlCommand(_delete, connection))
            {
                command.Parameters.AddWithValue("@idIncendio", id);
                command.ExecuteNonQuery();
            }
        }

        public void Update(CombateIncendio _combate)
        {
            SqlConnection connection = ContextFactory.Instancia();
            using (SqlCommand command = new SqlCommand(_update, connection))
            {
                command.Parameters.AddWithValue("@meioApropriado", _combate.MeioApropriado);
                command.Parameters.AddWithValue("@perigoEspecifico", _combate.PerigoEspecifico);
                command.Parameters.AddWithValue("@idIncendio", _combate.Id);
                command.ExecuteNonQuery();
            }
        }

        public CombateIncendio SelectByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
