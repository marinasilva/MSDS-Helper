using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using MSDSHelper.Model;

namespace MSDSHelper.DAL
{
    public class DangerDao : IDao<Danger>
    {
        private const string ADICIONAR = @"INSERT  INTO Danger ([Inalacao],[ContatoOlhos],[ContatoPele],[Ingestao],[Descricao])
                                                    VALUES      (@inalacao, @olhos, @pele, @ingestao, @descricao)";
        private const string SELECT_LAST = @"SELECT TOP 1 FROM DANGER ORDER BY IDDANGER";
        private const string UPDATE = @"UPDATE Danger SET [Inalacao] = @inalacao, [ContatoOlhos] = @olhos, [ContatoPele] = @pele, [Ingestao] = @ingestao, [Descricao] = @descricao
                                         WHERE idDanger = @idDanger";
        private const string SELECT_BY_ID = @"SELECT * FROM DANGER WHERE IDDANGER = @idDanger";
        private const string DELETE = @"DELETE FROM DANGER WHERE IDDANGER = @idDanger";

        public void Adicionar(Danger danger)
        {
            SqlConnection connection = ContextFactory.Instancia();
            using (SqlCommand command = new SqlCommand(ADICIONAR, connection))
            {
                command.Parameters.AddWithValue("@inalacao", danger.Inalacao);
                command.Parameters.AddWithValue("@olhos", danger.ContatoOlhos);
                command.Parameters.AddWithValue("@pele", danger.ContatoPele);
                command.Parameters.AddWithValue("@ingestao", danger.Ingestao);
                command.Parameters.AddWithValue("@descricao", danger.Descricao);
                command.ExecuteNonQuery();
            }
        }

        public Danger SelectLast()
        {
            SqlConnection connection = ContextFactory.Instancia();
            Danger danger;
            using (SqlCommand command = new SqlCommand(SELECT_LAST, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    danger = null;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            danger = new Danger();
                            danger.Id = Convert.ToInt32(reader["idDanger"]);
                            danger.ContatoOlhos = reader["ContatoOlhos"].ToString();
                            danger.ContatoPele = reader["ContatoPele"].ToString();
                            danger.Inalacao = reader["Inalacao"].ToString();
                            danger.Ingestao = reader["Ingestao"].ToString();
                            danger.Incendio.Id = Convert.ToInt32(reader["idIncendio"]);
                            danger.Descricao = reader["Descricao"].ToString();
                        }
                    }
                }
            }
            return danger;
        }

        public void Delete(int id)
        {
            SqlConnection connection = ContextFactory.Instancia();
            using (SqlCommand command = new SqlCommand(DELETE, connection))
            {
                command.Parameters.AddWithValue("@idDanger", id);
                command.ExecuteNonQuery();
            }
        }

        public void Update(Danger danger)
        {
            SqlConnection connection = ContextFactory.Instancia();
            using (SqlCommand command = new SqlCommand(UPDATE, connection))
            {
                command.Parameters.AddWithValue("@idDanger", danger.Id);
                command.Parameters.AddWithValue("@inalacao", danger.Inalacao);
                command.Parameters.AddWithValue("@olhos", danger.ContatoOlhos);
                command.Parameters.AddWithValue("@pele", danger.ContatoPele);
                command.Parameters.AddWithValue("@ingestao", danger.Ingestao);
                command.Parameters.AddWithValue("@descricao", danger.Descricao);
                command.ExecuteNonQuery();
            }
        }

        public Danger SelectByID(int id)
        {
            SqlConnection connection = ContextFactory.Instancia();
            Danger danger;
            using (SqlCommand command = new SqlCommand(SELECT_BY_ID, connection))
            {
                command.Parameters.AddWithValue("@idDanger", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    danger = null;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            danger = new Danger();
                            danger.Id = Convert.ToInt32(reader["idDanger"]);
                            danger.ContatoOlhos = reader["ContatoOlhos"] == DBNull.Value
                                ? string.Empty
                                : reader["ContatoOlhos"].ToString();
                            danger.ContatoPele = reader["ContatoPele"] == DBNull.Value
                                ? string.Empty
                                : reader["ContatoPele"].ToString();
                            danger.Inalacao = reader["Inalacao"] == DBNull.Value ? string.Empty : reader["Inalacao"].ToString();
                            danger.Incendio.Id = reader["idIncendio"] == DBNull.Value
                                ? 0
                                : Convert.ToInt32(reader["idIncendio"]);
                            danger.Ingestao = reader["Ingestao"] == DBNull.Value ? string.Empty : reader["Ingestao"].ToString();
                        }
                    }
                }
            }
            return danger;  
        }
    }
}
