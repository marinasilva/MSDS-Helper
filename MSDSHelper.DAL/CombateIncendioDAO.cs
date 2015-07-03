using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using MSDSHelper.Model;

namespace MSDSHelper.DAL
{
    public class CombateIncendioDao : IDao<CombateIncendio>
    {
        private const string ADICIONAR = @"INSERT INTO CombateIncendio  ([MeioApropriado],[PerigoEspecifico]) VALUES (@meioApropriado, @perigoEspecifico)";

        private const string SELECT_LAST = @"SELECT TOP 1 idIncendio,MeioApropriado,PerigoEspecifico FROM COMBATEINCENDIO ORDER BY  idIncendio desc";

        private const string SELECT_BY_ID = @"SELECT [idIncendio],[MeioApropriado],[PerigoEspecifico] FROM [CombateIncendio] WHERE idIncendio = @idincendio";

        private const string UPDATE = @"UPDATE CombateIncendio SET [MeioApropriado] = @meioApropriado, [PerigoEspecifico] = @perigoEspecifico WHERE idIncendio = @idIncendio";

        private const string DELETE = @"DELETE FROM COMBATEINCENDIO WHERE IDINCENDIO = @idIncendio";

        public void Adicionar(CombateIncendio combateIncendio)
        {
            SqlConnection connection = ContextFactory.Instancia();
            using (SqlCommand command = new SqlCommand(ADICIONAR, connection))
            {
                command.Parameters.AddWithValue("@meioApropriado", combateIncendio.MeioApropriado);
                command.Parameters.AddWithValue("@perigoEspecifico", combateIncendio.PerigoEspecifico);
                command.ExecuteNonQuery();
            }
        }

        public CombateIncendio SelectLast()
        {
            SqlConnection connection = ContextFactory.Instancia();
            CombateIncendio combate;
            using (SqlCommand command = new SqlCommand(SELECT_LAST, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    combate = null;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            combate = new CombateIncendio();
                            combate.Id = Convert.ToInt32(reader["idIncendio"]);
                            combate.MeioApropriado = reader["MeioApropriado"].ToString();
                            combate.PerigoEspecifico = reader["PerigoEspecifico"].ToString();
                        }
                    }
                }
            }
            return combate;
        }

        public void Delete(int id)
        {
            SqlConnection connection = ContextFactory.Instancia();
            using (SqlCommand command = new SqlCommand(DELETE, connection))
            {
                command.Parameters.AddWithValue("@idIncendio", id);
                command.ExecuteNonQuery();
            }
        }

        public void Update(CombateIncendio danger)
        {
            SqlConnection connection = ContextFactory.Instancia();
            using (SqlCommand command = new SqlCommand(UPDATE, connection))
            {
                command.Parameters.AddWithValue("@meioApropriado", danger.MeioApropriado);
                command.Parameters.AddWithValue("@perigoEspecifico", danger.PerigoEspecifico);
                command.Parameters.AddWithValue("@idIncendio", danger.Id);
                command.ExecuteNonQuery();
            }
        }

        public CombateIncendio SelectByID(int id)
        {
            SqlConnection connection = ContextFactory.Instancia();
            CombateIncendio combate;
            using (SqlCommand command = new SqlCommand(SELECT_BY_ID, connection))
            {
                command.Parameters.AddWithValue("@idincendio", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    combate = null;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            combate = new CombateIncendio();
                            combate.Id = Convert.ToInt32(reader["idIncendio"]);
                            combate.MeioApropriado = reader["MeioApropriado"].ToString();
                            combate.PerigoEspecifico = reader["PerigoEspecifico"].ToString();
                        }
                    }
                }
            }
            return combate;
        }
    }
}
